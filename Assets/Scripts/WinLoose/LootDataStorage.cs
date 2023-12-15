using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LootDataStorage")]
public class LootDataStorage : ScriptableObject
{
    public LootCollection[] Items;
}

[Serializable]
public class LootCollection
{
    public string key;
    public LootItem[] Items;
}

[Serializable]
public class LootItem
{
    public string ItemKey;
    public float Weight;
}