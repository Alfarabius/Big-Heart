using System.Threading.Tasks;
using Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ItemSystem
{
    public static class ItemFactory
    {
        /// <summary>
        /// Загружает предмет из Addressables и создаёт его в сцене (асинхронная версия).
        /// </summary>
        public static async Task<ItemMono> CreateItemAsync(string itemId, Vector3 position = default, Transform parent = null)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(itemId);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject prefab = handle.Result;
                GameObject itemObject = Object.Instantiate(prefab, position, Quaternion.identity, parent);
                ItemMono newItem = itemObject.GetComponent<ItemMono>();

                if (newItem != null)
                {
                    ItemService.Instance.RegisterItem(newItem);
                    Debug.Log($"[ItemFactory] Создан предмет {itemId}.");
                    return newItem;
                }
                else
                {
                    Debug.LogError($"[ItemFactory] Ошибка: У префаба {itemId} отсутствует ItemMono!");
                    Object.Destroy(itemObject);
                }
            }
            else
            {
                Debug.LogError($"[ItemFactory] Ошибка загрузки предмета {itemId} из Addressables!");
            }

            return null;
        }
    }
}
