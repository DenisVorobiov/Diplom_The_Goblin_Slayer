using System;
using TMPro;
using UnityEngine;

public class LocalizedTextView : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI _text;

    private object[] _parameters;

    public void Start()
    {
        Context.Instance.LocalizationSystem.OnLanguageChanged += DisplayLocalization;
        DisplayLocalization();
    }

    private void OnDestroy()
    {
        Context.Instance.LocalizationSystem.OnLanguageChanged -= DisplayLocalization;
    }

    public void DisplayLocalization()
    {
        if (_parameters == null || _parameters.Length == 0)
            _text.text = Context.Instance.LocalizationSystem.GetValue(key);
        else
            _text.text = string.Format(Context.Instance.LocalizationSystem.GetValue(key), _parameters);
        
        //_text.text = _parameters == null ? Context.Instance.LocalizationSystem.GetValue(key) 
        //: string.Format(Context.Instance.LocalizationSystem.GetValue(key), _parameters);
    }

    public void SetParameters(object[] parameters)
    {
        _parameters = parameters;
        DisplayLocalization();
    }
}