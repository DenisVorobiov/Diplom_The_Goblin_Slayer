using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    [SerializeField] private int recoveryAmount;
    [SerializeField] private float cooldownTime = 5f;
    private float lastUsageTime;
    public event Action OnRecover;

    public void Use()
    {
        if (Time.time - lastUsageTime >= cooldownTime)
        {
            Recover();
           
            OnRecover?.Invoke();
            // Destroy(gameObject);
            lastUsageTime = Time.time;
        }
       
    }

    private void Recover()
    {
        Health health = GetComponent<Health>();
        
        if (health != null)
        {
            health.Restore(recoveryAmount);
        }
    }
}