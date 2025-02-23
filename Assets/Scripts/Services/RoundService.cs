using Rounds;
using UnityEngine;

namespace Services
{
    public class RoundService : MonoBehaviour
    {
        #region SINGLETON
        private static RoundService _instance;
        
        public static RoundService Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("RoundService");
                    _instance = singletonObject.AddComponent<RoundService>();
                    DontDestroyOnLoad(singletonObject);
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion SINGLETON
        
        private IRoundOnUpdate _roundOnUpdate;

        public void StartDate()
        {
            _roundOnUpdate = new DateRound();
            _roundOnUpdate.StartRound();
        }

        private void Update()
        {
            _roundOnUpdate?.Update(Time.deltaTime);
        }
    }
}