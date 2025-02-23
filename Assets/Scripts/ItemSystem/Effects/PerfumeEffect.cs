using Configs;
using Rounds;
using Services;
using UnityEngine;

namespace ItemSystem
{
    public class PerfumeEffect : IEffect
    {
        private Animator _animator;
        private ItemConfig _itemConfig;
        
        public bool IsDateActive { get; private set; }
        
        public PerfumeEffect(Animator animator, ItemConfig config)
        {
            _animator = animator;
            _itemConfig = config;
        }
        
        public void OnEquip()
        {
        }

        public void OnUnEquip()
        {
        }

        public void OnDateStart()
        {
            IsDateActive = true;
            CoroutineService.Instance.RunRepeatingCoroutine(PeriodicEffect, _itemConfig.repeatIntervalTime, () =>  !IsDateActive);
        }

        public void OnDateEnd()
        {
            IsDateActive = false;
        }

        public void PeriodicEffect()
        {
            EventService.UpdateDateProgress(_itemConfig.effectValue);
        }
    }
}