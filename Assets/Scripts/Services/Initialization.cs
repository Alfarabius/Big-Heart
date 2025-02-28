namespace Services
{
    public static class Initialization
    {
        public static void Initialize()
        {
            ConfigService.Instance.Init();
            CoroutineService.Instance.Init();
            EventService.Instance.Init();
            InventoryService.Instance.Init();
            ItemService.Instance.Init();
            SceneManagerService.Instance.Init();
            SaveLoadService.Instance.Init();
        }
    }
}