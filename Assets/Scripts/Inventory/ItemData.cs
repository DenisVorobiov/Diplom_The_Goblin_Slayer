using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemData
{
    public string Name;
    public Sprite Icon;
    public ItemType ItemType;
    public int Armor;
    public int Damage;
    public string Description;
    public GameObject ItemPrefab;
    public Collider collider;
}