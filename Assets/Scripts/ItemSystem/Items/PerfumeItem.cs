using System;
using UnityEngine;

namespace ItemSystem
{
    public class PerfumeItem : BaseItemMono
    {
        private Animator _animator;
        private PerfumeEffect _perfumeEffect;
        public override SlotType GetSlotType() => SlotType.Perfume;
        public override IEffect Effect => _perfumeEffect;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _perfumeEffect = new PerfumeEffect(_animator);
            Effect.OnEquip();
        }
        
    }
}