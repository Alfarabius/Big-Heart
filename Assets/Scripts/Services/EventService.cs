using System;
using UnityEngine;

namespace Services
{
    public class EventService : BaseServiceSingleton<EventService>
    {
        public Action<float> OnDatePositiveProgressUpdate;
        public Action<float> OnDateNegativeProgressUpdate;
        
        public override void Init()
        {
            base.Init();
            Debug.Log("EventService initialized");
        }
    }
}
