public class InventoryItem
{
    public ItemData ItemData;
    public ItemType ItemType => ItemData.ItemType;
    public int Count;

    public InventoryItem(ItemData itemData, int count = 1)
    {
        ItemData = itemData;
        Count = count;
    }
}