using System;
using ItemSystem;
using Services;

namespace Rounds
{
    public class DateRound : IRoundOnUpdate
    {
        private float _roundDuration;
        private float _currentRoundTime;
        
        public bool IsRunning { get; private set; }
        public float GetRoundDuration() => _roundDuration;
        public float GetRoundTime() => _currentRoundTime;
        
        public event Action OnStartRound;
        public event Action OnEndRound;

        public DateRound()
        {
            var configService = ConfigService.Instance;
            _roundDuration = configService.roundsConfig.dateDuration;
        }

        public void StartRound()
        {
            IsRunning = true;
            ApplyEffects(effect => effect.OnDateStart());
            OnStartRound?.Invoke();
        }

        public void EndRound()
        {
            IsRunning = false;
            ApplyEffects(effect => effect.OnDateEnd());
            EventService.DateEnd();
            OnEndRound?.Invoke();
        }

        public void Update(float deltaTime)
        {
            if (!IsRunning)
            {
                return;
            }
            
            _currentRoundTime += deltaTime;
            if (_currentRoundTime >= _roundDuration)
            {
                EndRound();
            }
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