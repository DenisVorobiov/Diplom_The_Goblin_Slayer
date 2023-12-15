using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemsStorage")]
public class ShopItemsStorage : ScriptableObject
{
    public ShopItem[] Items;
}

[Serializable]
public class ShopItem
{
    public string ItemName;
    public int Price;
}