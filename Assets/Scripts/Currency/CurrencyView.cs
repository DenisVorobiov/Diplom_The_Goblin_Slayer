using System;
using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private LocalizedTextView _localizedText;
    [SerializeField] private bool _isSoft;
    private Currency _currency;

    private void Start()
    {
        _currency = _isSoft
            ? Context.Instance.CurrencySystem.SoftCurrency
            : Context.Instance.CurrencySystem.HardCurrency;
        _currency.OnChanged += SetAmount;
        SetAmount();
    }

    private void OnDestroy()
    {
        _currency.OnChanged -= SetAmount;
    }

    public void AddCurrency(int amount)
    {
        _currency.Amount += amount;
    }

    private void SetAmount()
    {
        _localizedText.SetParameters(new object[] { _currency.Amount });
    }
}