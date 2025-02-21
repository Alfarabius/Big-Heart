using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace ItemSystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryCapacityConfig inventoryCapacityConfig;
        [SerializeField] private BaseItemMono testItem;
        [SerializeField] private float placementRadius = 2.5f;
        
        // это нужно только для того, чтобы следить за размером инвентаря
        private Dictionary<SlotType, List<BaseItemMono>> _itemsBySlot;
        private Dictionary<SlotType, int> _inventoryCapacity;

        // а вот тут уже сами айтемы списком.
        // SerializeField только для наглядности в инспекторе, его нельзя менять через инспектор, только смотреть
        [SerializeField] private List<BaseItemMono> _items;
        
        private void Awake()
        {
            _inventoryCapacity = inventoryCapacityConfig.ToDictionary();
            _itemsBySlot = new Dictionary<SlotType, List<BaseItemMono>>();
            foreach (var slotType in _inventoryCapacity.Keys)
            {
                _itemsBySlot[slotType] = new List<BaseItemMono>();
            }
        }
        
        private void ArrangeItemsInCircle()
        {
            int itemCount = _items.Count;
            if (itemCount == 0) return;

            float angleStep = 360f / itemCount; // Угол между предметами
            float startAngle = 0f; // Начинаем с правой стороны

            for (int i = 0; i < itemCount; i++)
            {
                float angle = startAngle + (angleStep * i); // Угол для каждого объекта
                float radians = angle * Mathf.Deg2Rad; // Конвертируем в радианы

                Vector3 newPosition = new Vector3(
                    transform.position.x + Mathf.Cos(radians) * placementRadius, // X с учётом радиуса
                    transform.position.y + Mathf.Sin(radians) * placementRadius, // Y с учётом радиуса
                    transform.position.z // Z остаётся тем же (2D игра)
                );

                _items[i].transform.position = newPosition;
            }
        }

        public void AddItemTest()
        {
            var equippedItemsCount = _itemsBySlot[testItem.GetSlotType()].Count;
            var capacityForItem = _inventoryCapacity[testItem.GetSlotType()];
            if (!(equippedItemsCount < capacityForItem)) return;
            
            var newItem = Instantiate(testItem, transform);
            EquipItem(newItem);
            ArrangeItemsInCircle();
        }

        public bool EquipItem(BaseItemMono item)
        {
            var equippedItemsCount = _itemsBySlot[item.GetSlotType()].Count;
            var capacityForItem = _inventoryCapacity[item.GetSlotType()];
            if (equippedItemsCount < capacityForItem)
            {
                _itemsBySlot[item.GetSlotType()].Add(item);
                _items.Add(item);
                Debug.Log($"Added. Items count: {_items.Count}");
                item.Effect.OnEquip();
                return true;
            }

            return false;
        }

        public bool UnEquipItem(BaseItemMono item)
        {
            var equippedItemsCount = _itemsBySlot[item.GetSlotType()].Count;
            if (equippedItemsCount > 0)
            {
                _itemsBySlot[item.GetSlotType()].Remove(item);
                _items.Remove(item);
                item.Effect.OnUnEquip();
                return true;
            }
            return false;
        }
    }
}