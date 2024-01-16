using System;
using UnityEngine;
using UnityEngine.UI;

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
    public Image Sprite;
}