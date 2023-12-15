using System;
using UnityEngine;

[Serializable]
public class Currency
{
   [SerializeField] private int _amount;

    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnChanged?.Invoke();
        }
    }

    [SerializeField] private string _name;
    public string Name => _name;
    public event Action OnChanged;

    public Currency(int amount, string name)
    {
        _amount = amount;
        _name = name;
    }
}