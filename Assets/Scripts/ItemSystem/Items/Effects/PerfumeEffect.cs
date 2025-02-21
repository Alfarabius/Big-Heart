using UnityEngine;

namespace ItemSystem
{
    public class PerfumeEffect : IEffect
    {
        private Animator _animator;
        
        public PerfumeEffect(Animator animator)
        {
            _animator = animator;
        }
        
        public void OnEquip()
        {
            Debug.Log("Perfume OnEquip");
        }

        public void OnUnEquip()
        {
            Debug.Log("Perfume OnUnEquip");
        }

        public void OnDateStart()
        {
            Debug.Log("Perfume OnDateStart");
        }

        public void OnDateEnd()
        {
            Debug.Log("Perfume OnDateEnd");
        }

        public void AtIntervals(float intervalTime)
        {
            Debug.Log("Perfume AtIntervals");
        }
    }
}