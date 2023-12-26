using System;

public interface IEquipmentSystem
{
    public InventorySlot[] Slots { get; }
}

public class EquipmentSystem : IEquipmentSystem
{
    private const string SaveKey = "equip";
    public InventorySlot[] Slots { get; private set; }

    public EquipmentSystem()
    {
        Init();

        foreach (var slot in Slots)
        {
            slot.OnSlotChanged += Save;
        }
    }

    private void Init()
    {
        var saveData = Context.Instance.SaveSystem.Load<InventoryItemsSave>(SaveKey);
        if (saveData == null)
        {
            Slots = new[]
            {
                new InventorySlot() {},
                new InventorySlot() {},
                new InventorySlot() {},
                new InventorySlot() {},
                new InventorySlot() {},
            };
        }
        else
        {
            Slots = InventoryHelper.ConvertFromSaveFormat(saveData);
        }

        Slots[0].SlotType = ItemType.Weapon;
        Slots[1].SlotType = ItemType.Shild;
        Slots[2].SlotType = ItemType.Dagger;
        Slots[3].SlotType = ItemType.HealingPotion;
        Slots[4].SlotType = ItemType.ManaPotion;
        
    }

    public void Save()
    {
        InventoryItemsSave saveObject = InventoryHelper.ConvertToSaveFormat(Slots);
        Context.Instance.SaveSystem.Save(SaveKey, saveObject);
    }
}