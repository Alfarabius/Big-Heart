using ItemSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    /// <summary>
    /// Инвентарь самостоятельно получает все слоты внутри себя. Важное условие чтоб элемент обозначенный как слот обладал скриптом InventorySlot
    /// </summary>
    public class Inventory: MonoBehaviour
    {
        [SerializeField] List<SlotType> _slotType = new (); //какие типы предметов могут храниться в инвентаре

        public List<InventorySlot> _listSlots = new (); // все слоты в данном инвентаре

        private void Start()
        {
            GetAllSlotInventory();
        }

        private void GetAllSlotInventory()
        {
            _listSlots.Clear(); // очищаем воизбежания дублей

            int childCount = transform.childCount; 

            for (int i = 0; i < childCount; i++)
            {
                var slot = transform.GetChild(i).GetComponent<InventorySlot>();
                if(slot != null)
                {
                    _listSlots.Add(slot);
                    slot.SlotType = _slotType;
                }
            }
        }
        //Добавляет предмет в первый пустой слот
        public void AddItem(BaseItemMono item)
        {
            var typeItem = item.GetSlotType();
            if(_slotType.Contains(typeItem))
            {
                var emptySlot = _listSlots.FirstOrDefault(s => s.Item == null);
                emptySlot.Add(item);
            }
        }
    }
}
