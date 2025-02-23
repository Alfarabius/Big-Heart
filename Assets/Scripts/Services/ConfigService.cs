using Configs;
using Rounds;
using UnityEngine;

namespace Services
{
    public class ConfigService : MonoBehaviour {
        
    #region SINGLETON
    private static ConfigService _instance;
    
    public static ConfigService Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("ConfigService");
                _instance = singletonObject.AddComponent<ConfigService>();
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
        
        public RoundsConfig roundsConfig;
        public InventoryConfig inventoryConfig;
    }
}