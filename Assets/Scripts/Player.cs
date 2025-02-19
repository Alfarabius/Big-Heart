using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    
    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<Player>();
            if (_instance != null) return _instance;
            GameObject singleton = new GameObject(nameof(Player));
            _instance = singleton.AddComponent<Player>();
            DontDestroyOnLoad(singleton);
            return _instance;
        }
    }

    private void Awake()
    {
        MakeSingleton();
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    private void MakeSingleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}