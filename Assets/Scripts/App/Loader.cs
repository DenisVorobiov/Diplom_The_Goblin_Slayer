using System;
using UnityEngine;

    public class Loader : MonoBehaviour
    {
    [SerializeField] private EntityDataStorage _entityDataStorage;
    [SerializeField] private SpawnDataStorage _spawnDataStorage;
    [SerializeField] private ItemsDataStorage _itemsDataStorage;
    [SerializeField] private LootDataStorage _lootDataStorage;
    [SerializeField] private ShopItemsStorage _shopItemsStorage;
    [SerializeField] private LocalizationStorage _localizationStorage;


    private void Start()
    {
        Context.Initialize(
            _entityDataStorage, 
            _spawnDataStorage, 
            _itemsDataStorage,
            _lootDataStorage,
            _shopItemsStorage,
            _localizationStorage);
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMainMenu);
    }
    [ContextMenu("DeleteSave")]
    public void OnDestroy()
    {
        PlayerPrefs.DeleteAll();
       // PlayerPrefs.DeleteKey();
    }
}
