using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _progressBar;

    public void Start()
    {
        _health.OnDamaged += OnDamaged;
    }

    private void OnDestroy()
    {
        _health.OnDamaged -= OnDamaged;
    }

    private void OnDamaged(int current, int max)
    {
        SetFill((float) current / (float) max);
    }

    private void SetFill(float fillAmount)
    {
        _progressBar.fillAmount = fillAmount;
    }
}
