using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(menuName = "ItemSystem/InventoryCapacityConfig")]
    public class InventoryCapacityConfig : ScriptableObject
    {
        [Header("Укажите вместимость для каждого типа слота")]
        public SlotCapacityEntry[] slotCapacities;

        [Serializable]
        public struct SlotCapacityEntry
        {
            public SlotType slotType;
            public int capacity;
        }
        
        public Dictionary<SlotType, int> ToDictionary()
        {
            var dict = new Dictionary<SlotType, int>();
            foreach (var entry in slotCapacities)
            {
                dict[entry.slotType] = entry.capacity;
            }
            return dict;
        }
    }
}