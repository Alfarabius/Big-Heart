using ItemSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class InventorySlot: MonoBehaviour
    {
        private BaseItemMono item = null;
        public BaseItemMono Item { get { return item; } }
        public List<SlotType> SlotType { get; set; }

        public bool Locked = false;
        private void Start()
        {
            InitSlot();
        }
        void Update()
        {
            if (item != null && transform.position != item.gameObject.transform.position && !Input.GetMouseButton(0))
            {
                Move();
            }
        }
        public void Move()
        {
            item.transform.position = transform.position;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var item = collision.gameObject.GetComponent<BaseItemMono>();
            if (item != null && this.item == null)
            {
                Add(item);
            }
        }
        public void Add(BaseItemMono item)
        {
            var typeItem = item.GetSlotType();
            if (SlotType.Contains(typeItem))
            {
                this.item = item;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            var item = collision.gameObject.GetComponent<BaseItemMono>();
            if (item == this.item)
            {
                this.item = null;
            }
        }
        private void InitSlot()
        {
            var collider = GetComponent<Collider2D>();
            if(collider != null)
            {
                collider.isTrigger = true;
            }
            var rb =GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                rb.freezeRotation = true;
            }
        }
    }
}
