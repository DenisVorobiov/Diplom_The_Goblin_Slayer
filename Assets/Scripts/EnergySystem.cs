using System;
using System.Collections;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    private int currentEnergy;

    public float energyRestoreRate = 5.0f; // Кількість одиниць енергії, яка відновлюється кожну секунду
    public int CurrentEnergy { get; private set; }
    // Подія, яка викликається при зміні енергії
    public event Action<int, int> OnEnergyChanged;

    private void Start()
    {
       
        StartCoroutine(RestoreEnergyRoutine());
    }

    public void SetEnergy(int newEnergy)
    {
        CurrentEnergy = newEnergy;
        maxEnergy = newEnergy;
    }

    public void Actions(int damage)
    {
        CurrentEnergy -= damage;
        if (CurrentEnergy <= 0)
            OnNoEnergy();
        OnEnergyChanged?.Invoke(CurrentEnergy,maxEnergy);
    }

    private IEnumerator RestoreEnergyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); // Чекаємо 1 секунду

            if (CurrentEnergy < maxEnergy)
            {
                CurrentEnergy += Mathf.RoundToInt(energyRestoreRate); // Округляємо вверх, якщо потрібно
                CurrentEnergy = Mathf.Min(CurrentEnergy, maxEnergy);

                OnEnergyChanged?.Invoke(CurrentEnergy, maxEnergy);
            }
        }
    }
    private void OnNoEnergy()
    {
        
    }
}