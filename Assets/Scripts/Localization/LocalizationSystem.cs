using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ILocalizationSystem
{
    string CurrentLanguageKey { get; set; }
    event Action OnLanguageChanged;
    string GetValue(string key);
}

public class LocalizationSystem : ILocalizationSystem
{
    public const string LangSaveKey = "current_language";
    private string _currentLanguage;

    public string CurrentLanguageKey
    {
        get => _currentLanguage;
        set
        {
            _currentLanguage = value;
            OnLanguageChanged?.Invoke();
        }
    }

    public event Action OnLanguageChanged;
    private Dictionary<string, Dictionary<string, string>> _localizationDictionary;


    public LocalizationSystem()
    {
        var localizationItems = Context.Instance.DataSystem.LocalizationItems;

        InitCurrentLanguage();
        OnLanguageChanged += Save;

        _localizationDictionary = new Dictionary<string, Dictionary<string, string>>();
        foreach (var item in localizationItems)
        {
            foreach (var result in item.languages)
            {
                if (!_localizationDictionary.ContainsKey(item.key))
                    _localizationDictionary.Add(item.key, new Dictionary<string, string>());

                _localizationDictionary[item.key].Add(result.languageKey, result.localized);
            }
        }
    }

    private void InitCurrentLanguage()
    {
        var currentLanguage = Context.Instance.SaveSystem.Load(LangSaveKey);
        if (string.IsNullOrEmpty(currentLanguage))
        {
            currentLanguage = Context.Instance.DataSystem.LanguageKeys[1];
        }

        CurrentLanguageKey = currentLanguage;
    }

    private void Save()
    {
        Context.Instance.SaveSystem.Save(LangSaveKey, CurrentLanguageKey);
    }

    public string GetValue(string key) //"exit" => Вихід
    {
        if (_localizationDictionary.ContainsKey(key))
            if (_localizationDictionary[key].ContainsKey(CurrentLanguageKey))
                return _localizationDictionary[key][CurrentLanguageKey];
        return key;

        /*foreach (LocalizationItem localizationItem in values)
        {
            if (localizationItem.key == key)
            {
                foreach (LocalizedValue locValue in localizationItem.values)
                {
                    if (locValue.languageKey == CurrentLanguageKey)
                    {
                        return locValue.value;
                    }
                }
            }
        }
        return key;*/

        /*LocalizationItem item = values.First(v => v.key == key);
        LocalizedValue localizationValue = item.values.First(v => v.languageKey == CurrentLanguageKey);
        return localizationValue.value;*/

        /*return values.FirstOrDefault(v => v.key == key)
            ?.languages.FirstOrDefault(v => v.languageKey == CurrentLanguageKey)
            ?.localized ?? key;*/
    }
}