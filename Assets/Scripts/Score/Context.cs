

public class Context
{
    private static Context _instance;
    public static Context Instance => _instance ??= new Context();

    public bool IsInitialized { get; private set; }
    public IScoreSystem ScoreSystem { get; private set; }
    public IAppSystem AppSystem { get; private set; }
    public IDataSystem DataSystem { get; private set; }
    public IWinSystem WinSystem { get; private set; }
    public IInventorySystem InventorySystem { get; private set; }
    public IEquipmentSystem EquipmentSystem { get; private set; }
    public IItemBarSystem ItemBarSystem { get; private set; }
    public ICurrencySystem CurrencySystem { get; private set; }
    public IAudioSystem AudioSystem { get; private set; }
    public ILocalizationSystem LocalizationSystem { get; private set; }
    public ISaveSystem SaveSystem { get; private set; }


    private Context()
    {
    }

    public static void Initialize(
        EntityDataStorage entityData,
        SpawnDataStorage spawnDataStorage,
        ItemsDataStorage itemsStorage,
        LootDataStorage lootDataStorage,
        ShopItemsStorage shopItemsStorage,
        LocalizationStorage localizationStorage)
    {
        Instance.DataSystem = new DataSystem(
           entityData,
           spawnDataStorage,
           itemsStorage,
           lootDataStorage,
           shopItemsStorage,
           localizationStorage);

        Instance.SaveSystem = new SaveSystem();
        Instance.ScoreSystem = new ScoreSystem();
        Instance.AppSystem = new AppSystem();
        Instance.WinSystem = new WinSystem();
        Instance.InventorySystem = new InventorySystem();
        Instance.EquipmentSystem = new EquipmentSystem();
        Instance.ItemBarSystem = new ItemBarSystem();
        Instance.CurrencySystem = new CurrencySystem();
        Instance.AudioSystem = new AudioSystem();
        Instance.LocalizationSystem = new LocalizationSystem();
        Instance.IsInitialized = true;
    }
}