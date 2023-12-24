using UnityEngine.UI;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] private EnergySystem _energySystem;
    [SerializeField] private Image _progressBar;

    private void Start()
    {
        
            _energySystem.OnEnergyChanged += OnEnergyChanged;
    }

    private void OnDestroy()
    {
        
            _energySystem.OnEnergyChanged -= OnEnergyChanged;
    }

    private void OnEnergyChanged(int current, int max)
    {
        SetFill((float)current / (float)max);
    }

    private void SetFill(float fillAmount)
    {
       
            _progressBar.fillAmount = fillAmount;
    }
}