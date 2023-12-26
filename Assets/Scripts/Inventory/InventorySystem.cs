using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public interface IInventorySystem
{
    InventorySlot[] Slots { get; }
    void AddItem(InventoryItem item);
}

public class InventorySystem : IInventorySystem
{
    public const int InventorySize = 10;

    public InventorySlot[] Slots { get; private set; }

    public InventorySystem()
    {
        Slots = new InventorySlot[InventorySize];
        for (int i = 0; i < InventorySize; ++i)
        {
            Slots[i] = new InventorySlot() {SlotType = ItemType.All};
        }

        
        /* var items = Context.Instance.DataSystem.ItemsData;
        for (int i = 0; i < items.Length; ++i)
        {
            AddItem(new InventoryItem(items[i]));
        }*/

    }

    public void AddItem(InventoryItem item)
    {
        foreach (var slot in Slots)
        {
            if (slot.IsEmpty)
            {
                slot.Item = item;
                return;
            }
        }
    }

    private void Log()
    {
        for (int i = 0; i < InventorySize; ++i)
        {
            var result = Slots[i].IsEmpty ? "_" : Slots[i].Item.ItemData.Name;
            Debug.Log($"{i}:{Slots[i].SlotType}:{result}");
        }
    }
    
}