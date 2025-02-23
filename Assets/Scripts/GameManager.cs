using ItemSystem;
using Rounds;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player _player;
    private IRoundOnUpdate _roundOnUpdate;

    private async void Start()
    {
        InventoryService inventory = InventoryService.Instance;

        ItemMono item = await ItemFactory.CreateItemAsync("FirstPerfume");
        inventory.EquipItem(item);
        item = await ItemFactory.CreateItemAsync("RichPerfume");
        inventory.EquipItem(item);

        RoundService.Instance.StartDate();
    }
}