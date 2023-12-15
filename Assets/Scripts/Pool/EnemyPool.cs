using System.Collections.Generic;
using UnityEngine;

public class EnemyPool<T>
    where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _pool;
    //private Vector3 _spawnPosition;
    //private Quaternion _spawnRotation;

    public EnemyPool(T prefab, int prewarmSize = 0)
    {
        _prefab = prefab;
        _pool = new List<T>(prewarmSize);
        for (int i = 0; i < prewarmSize; ++i)
        {
            CreateInstance(Vector3.zero, Quaternion.identity);
        }
    }

    public T GetObject(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        foreach (var obj in _pool)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.transform.position = spawnPosition;
                obj.transform.rotation = spawnRotation;
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        return CreateInstance(spawnPosition, spawnRotation);
    }

    private T CreateInstance(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        var instance = GameObject.Instantiate(_prefab, spawnPosition, spawnRotation);
        instance.gameObject.SetActive(false);
        _pool.Add(instance);
        return instance;
    }
}