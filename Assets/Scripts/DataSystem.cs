public interface IDataSystem
{
    EntityData[] EntityData { get; }
    SpawnData[] SpawnData { get; }
    ItemData[] ItemsData { get; }
    LootCollection[] LootData { get; }
    ShopItem[] ShopItems { get; }
    LocalizationItem[] LocalizationItems { get; }
    string[] LanguageKeys { get; }
}

public class DataSystem : IDataSystem
{
    public EntityData[] EntityData { get; }
    public SpawnData[] SpawnData { get; }
    public ItemData[] ItemsData { get; }
    public LootCollection[] LootData { get; }
    public ShopItem[] ShopItems { get; }
    public LocalizationItem[] LocalizationItems { get; }
    public string[] LanguageKeys { get; }

    public DataSystem(
        EntityDataStorage entityDataStorage,
        SpawnDataStorage spawnDataStorage,
        ItemsDataStorage itemsStorage,
        LootDataStorage lootDataStorage,
        ShopItemsStorage shopItemsStorage,
        LocalizationStorage localizationStorage)
    {
        EntityData = entityDataStorage.entityData;
        SpawnData = spawnDataStorage.data;
        ItemsData = itemsStorage.Items;
        LootData = lootDataStorage.Items;
        ShopItems = shopItemsStorage.Items;
        LocalizationItems = localizationStorage.values;
        LanguageKeys = localizationStorage.LanguageKeys;
    }
}