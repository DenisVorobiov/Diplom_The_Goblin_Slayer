using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class AddGold : MonoBehaviour
{
    [SerializeField] private Health _Gold;
   
    private void Start()
    {
        _Gold.OnAddGold += HandleOnDie;
    }
    public void OnDestroy()
    {
        _Gold.OnAddGold -= HandleOnDie;
    }

    private void HandleOnDie()
    {
        Currency softCurrency = Context.Instance.CurrencySystem.SoftCurrency;
        softCurrency.Amount += 100;
        
    }
    
}
