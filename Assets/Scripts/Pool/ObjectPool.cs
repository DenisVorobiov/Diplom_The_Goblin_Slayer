using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T>
    where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _pool;
    private Transform _parent;

    public ObjectPool(T prefab, Transform parent = null, int prewarmSize = 0)
    {
        _prefab = prefab;
        _parent = parent;
        _pool = new List<T>(prewarmSize);
        for (int i = 0; i < prewarmSize; ++i)
        {
            CreateInstance();
        }
    }

    public T GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        var instance = CreateInstance();
        instance.gameObject.SetActive(true);
        return instance;
    }

    private T CreateInstance()
    {
        var instance = GameObject.Instantiate(_prefab, _parent);
        instance.gameObject.SetActive(false);
        _pool.Add(instance);
        return instance;
    }
}