using ItemSystem;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    public class DragAndDropItem: MonoBehaviour
    {
        private GameObject _objSelected;
        private Vector3 _startPositionItem; //позиция откуда взяли предмет
        private void Update()
        {
            //Заменить на нвоый инпут
            if (Input.GetMouseButtonDown(0))
            {
                CheckHitObject();
            }
            if (Input.GetMouseButton(0) && _objSelected != null)
            {
                DragObject();
            }
            if (Input.GetMouseButtonUp(0) && _objSelected != null)
            {
                DropObject();
            }
        }


        private void CheckHitObject()
        {
            var raycast = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            var raycastItemCplider = raycast.FirstOrDefault(i => i.collider.GetComponent<BaseItemMono>() != null);
            var raycastSlotColider = raycast.FirstOrDefault(i => i.collider.GetComponent<InventorySlot>() != null);

            if (raycastItemCplider.collider != null && raycastSlotColider.collider != null)
            {
                var slotLocked = raycastSlotColider.transform.gameObject.GetComponent<InventorySlot>().Locked;
                if (slotLocked == false)
                {
                    _startPositionItem = raycastItemCplider.collider.transform.position;
                    _objSelected = raycastItemCplider.transform.gameObject;
                }
            }
        }

        private void DragObject()
        {

            _objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10f));

        }
        private void DropObject()
        {
            var raycast = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            var raycastCollider = raycast.FirstOrDefault(i => i.collider.GetComponent<InventorySlot>() != null);
            if (raycastCollider.collider == null)
            {
                _objSelected.transform.position = _startPositionItem;
            } else
            {
                var slotType = raycastCollider.transform.gameObject.GetComponent<InventorySlot>().SlotType;
                var typeItem = _objSelected.gameObject.GetComponent<BaseItemMono>();
                if (!slotType.Contains(typeItem.GetSlotType()))
                {
                    _objSelected.transform.position = _startPositionItem;
                }
            }
            _objSelected = null;

        }
    }
}
