using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EntityInitializer : MonoBehaviour
{
    [SerializeField] private string entityKey;
    [SerializeField] private PlayerMovementNew movement;
    
    [SerializeField] private Health health;
    

    private void Start()
    {
        var data = Context.Instance.DataSystem.EntityData.FirstOrDefault(e => e.Name == entityKey);
        Initialize(data);
    }

    public void Initialize(EntityData data)
    {
        if (movement != null)
            movement.moveSpeed = data.Speed;
        
        health.SetHealth(data.Health);
    }

}