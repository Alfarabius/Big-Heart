using System.Collections.Generic;
using System.Threading.Tasks;
using ItemSystem;
using Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ItemFactory
{
    private readonly Dictionary<string, GameObject> _prefabCache = new(); // Кэш префабов

    /// <summary>
    /// Загружает предмет из Addressables и создаёт его в сцене (асинхронная версия).
    /// </summary>
    public async Task<ItemMono> CreateItemAsync(string itemId, Vector3 position = default, Transform parent = null)
    {
        GameObject prefab;

        // Проверяем, есть ли уже загруженный префаб в кэше
        if (_prefabCache.TryGetValue(itemId, out prefab))
        {
            Debug.Log($"[ItemFactory] Используем закешированный префаб для {itemId}");
        }
        else
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(itemId);
            prefab = await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _prefabCache[itemId] = prefab; // Кешируем загруженный префаб
            }
            else
            {
                Debug.LogError($"[ItemFactory] Ошибка загрузки предмета {itemId} из Addressables!");
                return null;
            }
        }

        // Создаём объект на сцене
        GameObject itemObject = Object.Instantiate(prefab, position, Quaternion.identity, parent);
        ItemMono newItem = itemObject.GetComponent<ItemMono>();

        if (newItem != null)
        {
            Debug.Log($"[ItemFactory] Создан предмет {itemId}.");
            return newItem;
        }
        else
        {
            Debug.LogError($"[ItemFactory] Ошибка: У префаба {itemId} отсутствует ItemMono!");
            Object.Destroy(itemObject);
        }

        return null;
    }
}
