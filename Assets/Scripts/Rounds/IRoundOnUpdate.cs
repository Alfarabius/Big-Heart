using System;

namespace Rounds
{
    public interface IRoundOnUpdate
    {
        float GetRoundDuration();
        float GetRoundTime();
        
        event Action OnStartRound;
        event Action OnEndRound;
        
        public void StartRound();
        public void EndRound();
        
        public void Update(float deltaTime);
    }
}