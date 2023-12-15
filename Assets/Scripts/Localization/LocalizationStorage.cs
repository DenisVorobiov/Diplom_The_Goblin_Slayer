using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationStorage")]
public class LocalizationStorage : ScriptableObject
{
    public string[] LanguageKeys;
    public LocalizationItem[] values;
}

[Serializable]
public class LocalizationItem
{
    public string key;
    public LanguageResult[] languages;
}

[Serializable]
public class LanguageResult
{
    public string languageKey;
    public string localized;
}