using System;
using System.Linq;

public static class InventoryHelper
{
    public static InventoryItemsSave ConvertToSaveFormat(InventorySlot[] slots)
    {
        InventoryItemsSave saveSlots = new InventoryItemsSave();
        saveSlots.Sltos = new SaveSlot[slots.Length];
        for (int i = 0; i < slots.Length; ++i)
        {
            var itemId = slots[i].IsEmpty ? "" : slots[i].Item.ItemData.Name;
            var count = slots[i].IsEmpty ? 0 : slots[i].Item.Count;
            saveSlots.Sltos[i] = new SaveSlot() {ItemId = itemId, Count = count};
        }

        return saveSlots;
    }

    public static InventorySlot[] ConvertFromSaveFormat(InventoryItemsSave slotsSave)
    {
        InventorySlot[] arr = new InventorySlot[slotsSave.Sltos.Length];
        var itemsData = Context.Instance.DataSystem.ItemsData;
        var saveSlots = slotsSave.Sltos;
        for (int i = 0; i < saveSlots.Length; ++i)
        {
            arr[i] = new InventorySlot();
            ItemData item = itemsData.FirstOrDefault(itemData => itemData.Name == saveSlots[i].ItemId);
            if(item != null)
                arr[i].Item = new InventoryItem(item, saveSlots[i].Count);
        }

        return arr;
    }
}

[Serializable]
public class InventoryItemsSave
{
    public SaveSlot[] Sltos;
}

[Serializable]
public class SaveSlot
{
    public string ItemId;
    public int Count;
}