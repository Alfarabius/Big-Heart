using System;
using UnityEngine;

namespace Services
{
    public static class EventService
    {
        public static event Action<float> OnDateProgressChanged;
        public static event Action OnDateEnd;

        public static void UpdateDateProgress(float progress)
        {
            OnDateProgressChanged?.Invoke(progress);
        }

        public static void DateEnd()
        {
            OnDateEnd?.Invoke();
            Debug.Log("DateEnd");
        }
    }
}
