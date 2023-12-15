using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarr : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider slider;
	public Gradient gradient;
    public Image fill;

	void Start()
	{
        health.OnDamaged += OnDamaged;
       
		fill.color = gradient.Evaluate(float.MaxValue);
	}
    private void OnDamaged(int current, int max)
    {
        SetFill((float)current / (float)max);
    }
    private void SetFill(float fillAmount)
    {
        slider.value = fillAmount;
        fill.color = gradient.Evaluate(fillAmount);
    }
    private void OnDestroy()
    {
        health.OnDamaged -= OnDamaged;
    }
}
