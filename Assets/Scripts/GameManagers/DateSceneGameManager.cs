using System;
using ItemSystem;
using Services;

namespace Rounds
{
    public class DateSceneGameManager : BaseGameManager
    {
        private float _roundDuration;
        private float _currentRoundTime;
        private RoundConfig _config;
        
        private void Awake()
        {
            _config = ConfigService.Instance.roundConfig;
        }
        
        protected override void Start()
        {
            base.Start();
            Initialization.Initialize();
            StartDate();
        }
        
        private void Update()
        {
            if (GameState == GameState.Paused)
            {
                return;
            }
        }

        private void StartDate()
        {
            ApplyEffects(effect => effect.OnDateStart());
        }
        
        public void EndDate()
        {
            ApplyEffects(effect => effect.OnDateEnd());
        }

        private void ApplyEffects(Action<IEffect> effectAction)
        {
            var items = InventoryService.Instance.Items;
            foreach (var item in items)
            {
                effectAction?.Invoke(item.Effect);
            }
        }
    }
}