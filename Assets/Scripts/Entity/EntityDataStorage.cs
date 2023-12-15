using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStorage")]
public class EntityDataStorage : ScriptableObject
{
    public EntityData[] entityData;

    public EntityData GetData(string key)
    {
        return entityData.FirstOrDefault(e => e.Name == key);
    }
}