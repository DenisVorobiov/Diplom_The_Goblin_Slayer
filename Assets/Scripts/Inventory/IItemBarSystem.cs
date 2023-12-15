public interface IItemBarSystem
{
    
    public InventorySlot[] Slots { get; }
}

public class ItemBarSystem : IItemBarSystem
{
    
    public InventorySlot[] Slots { get; }

    public ItemBarSystem()
    {
       
        Slots = new[]
        {
            new InventorySlot() {SlotType = ItemType.ManaPotion},
            new InventorySlot() {SlotType= ItemType.HealingPotion},
        };
    }
}