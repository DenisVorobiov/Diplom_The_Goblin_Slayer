using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    public void Start()
    {
        _dropdown.options = new List<TMP_Dropdown.OptionData>();
        string[] languages = Context.Instance.DataSystem.LanguageKeys;
        string currentLang = Context.Instance.LocalizationSystem.CurrentLanguageKey;
        int languageIndex = 0;

        foreach (string lang in languages)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData(lang));
            if (lang == currentLang)
                _dropdown.value = languageIndex;
            ++languageIndex;
        }
    }

    public void OnLanguageChanged(int index)
    {
        Context.Instance.LocalizationSystem.CurrentLanguageKey = Context.Instance.DataSystem.LanguageKeys[index];
    }
}