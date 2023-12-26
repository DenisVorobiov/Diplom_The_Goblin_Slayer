using System;
using System.Collections;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    private int currentEnergy;

    public float energyRestoreRate = 5.0f; 
    public int CurrentEnergy { get; private set; }
   
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
            yield return new WaitForSeconds(1.0f); 

            if (CurrentEnergy < maxEnergy)
            {
                CurrentEnergy += Mathf.RoundToInt(energyRestoreRate); 
                CurrentEnergy = Mathf.Min(CurrentEnergy, maxEnergy);

                OnEnergyChanged?.Invoke(CurrentEnergy, maxEnergy);
            }
        }
    }
    private void OnNoEnergy()
    {
        
    }
}