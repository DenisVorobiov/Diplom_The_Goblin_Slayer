using System.Linq;
using TMPro;
using UnityEngine;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _price;
    private ShopItem _data;

    public void SetData(ShopItem data)
    {
        _data = data;
        _name.text = data.ItemName;
        _price.text = data.Price.ToString();
    }

    public void Purchase()
    {
        var softCurrency = Context.Instance.CurrencySystem.SoftCurrency;
        if (_data.Price > softCurrency.Amount)
            return;
        softCurrency.Amount -= _data.Price;

        ItemData[] allItems = Context.Instance.DataSystem.ItemsData;
        ItemData winItem = allItems.FirstOrDefault(i => i.Name == _data.ItemName);

        if (winItem != null)
            Context.Instance.InventorySystem.AddItem(new InventoryItem(winItem));
    }
}