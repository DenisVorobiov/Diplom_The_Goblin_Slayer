using System;
using UnityEngine;

public class LoseView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Start()
    {
        _health.OnDamaged += OnHealthChanged;
    }

    private void OnHealthChanged(int current, int max)
    {
        if (current <= 0)
            Context.Instance.AppSystem.Trigger(AppTrigger.ToLooseScreen);
    }
}