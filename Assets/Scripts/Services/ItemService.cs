using System.Collections.Generic;
using ItemSystem;
using UnityEngine;

namespace Services
{
    public class ItemService : MonoBehaviour
    {
        #region SINGLETON
        private static ItemService _instance;
        
        public static ItemService Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("ItemService");
                    _instance = singletonObject.AddComponent<ItemService>();
                    DontDestroyOnLoad(singletonObject);
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion SINGLETON
        
        private static readonly Dictionary<string, ItemMono> _itemsById = new();

        public void RegisterItem(ItemMono item)
        {
            if (item == null || string.IsNullOrEmpty(item.ItemId)) return;

            if (!_itemsById.ContainsKey(item.ItemId))
            {
                _itemsById[item.ItemId] = item;
                Debug.Log($"[ItemService] Предмет {item.ItemId} добавлен в список регистраций.");
            }
            else
            {
                Debug.Log($"[ItemService] Предмет {item.ItemId} уже есть в списке регистраций.");
            }
        }

        public void UnregisterItem(string itemId)
        {
            if (_itemsById.TryGetValue(itemId, out ItemMono item))
            {
                _itemsById.Remove(itemId);
                Debug.Log($"[ItemService] Предмет {itemId} убран из списка регистраций.");
            }
        }

        public void DestroyItem(string itemId)
        {
            if (_itemsById.TryGetValue(itemId, out ItemMono item))
            {
                Object.Destroy(item.gameObject);
                _itemsById.Remove(itemId);
                Debug.Log($"[ItemService] Предмет {itemId} удалён.");
            }
        }

        public ItemMono GetItem(string itemId)
        {
            return _itemsById.TryGetValue(itemId, out var item) ? item : null;
        }

        public bool ContainsItem(string itemId)
        {
            return _itemsById.ContainsKey(itemId);
        }
    }
}