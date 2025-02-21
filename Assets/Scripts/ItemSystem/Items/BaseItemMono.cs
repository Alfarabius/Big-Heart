using UnityEngine;

namespace ItemSystem
{
    public abstract class BaseItemMono : MonoBehaviour
    {
        [SerializeField] private string itemId;
        [SerializeField] private ItemView view;
        
        public string ItemId => itemId;
        public abstract SlotType GetSlotType();
        public abstract IEffect Effect { get; }
    }
}