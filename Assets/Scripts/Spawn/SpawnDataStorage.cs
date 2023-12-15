using Unity.Properties;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnDataStorage")]
public class SpawnDataStorage : ScriptableObject
{
    public SpawnData[] data;
}