using System;
using UnityEngine;

public interface ISaveSystem
{
    void Save(string key, object saveObject);
    void Save(string key, string str);
    object Load(string key, Type type);
    string Load(string key);
    T Load<T>(string key);
}

public class SaveSystem : ISaveSystem
{
    #region Save

    public void Save(string key, object saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        PlayerPrefs.SetString(key, json);
        Debug.Log(json);
    }

    public void Save(string key, string str)
    {
        PlayerPrefs.SetString(key, str);
    }

    #endregion

    #region Load

    public object Load(string key, Type type)
    {
        string json = PlayerPrefs.GetString(key, "");

        if (string.IsNullOrEmpty(json))
            return default;

        object res = JsonUtility.FromJson(json, type);
        return res;
    }

    public string Load(string key)
    {
        return PlayerPrefs.GetString(key, "");
    }

    public T Load<T>(string key)
    {
        string json = PlayerPrefs.GetString(key, "");

        if (string.IsNullOrEmpty(json))
            return default;

        T res = JsonUtility.FromJson<T>(json);
        return res;
    }

    #endregion
}