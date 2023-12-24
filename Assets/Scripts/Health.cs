using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    private int maxHealth;
   
    [SerializeField] private Collider specificChildCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent meshAgent;
    [SerializeField] private GameObject enemyHealthBar;
    private bool isShieldRaised = false;
    private float shieldReductionPercentage = 1f;
    
    private Vector3 startPosition;
   
    public int CurrentHealth { get; private set; }
    public event Action<int, int> OnDamaged;
    public event Action OnDead;

    [SerializeField] public float time;
    [SerializeField] public float time2;
    private void Start()
    {
        startPosition = transform.position;

    }
    public void RaiseShield()
    {
        isShieldRaised = true;
    }

    public void LowerShield()
    {
        isShieldRaised = false;
    }
    public void SetHealth(int newHealth)
    {
        CurrentHealth = newHealth;
        maxHealth = newHealth;
    }

   public void Damage(int damage)
   {
       int actualDamage = damage;

       if (isShieldRaised)
       {
           actualDamage = Mathf.RoundToInt(actualDamage * (1 - shieldReductionPercentage));
       }
       CurrentHealth -= actualDamage;
        if (CurrentHealth <= 0)
            OnDie();
        OnDamaged?.Invoke(CurrentHealth,maxHealth);
    }
   private void OnDie()
    {
        Debug.Log("OnDie called");
        if (tag != "Player") 
            Context.Instance.ScoreSystem.AddScore(100);
        
        OnDead?.Invoke();
            enemyHealthBar.active = false;
            specificChildCollider.enabled = false;
            animator.enabled = false;
            meshAgent.enabled = false;
            StartCoroutine(DisableRoutine());
    }
    
    private IEnumerator DisableRoutine()
    {
        Debug.Log("DisableRoutine started");
        yield return new WaitForSeconds(time);
        Respawn();
        gameObject.SetActive(false);
    }
    public void Respawn()
    {
        Debug.Log("Respawn called");
        Respawn respawner = FindObjectOfType<Respawn>();
        if (respawner != null)
        {
            transform.position = startPosition;
            enemyHealthBar.active = true;
            animator.enabled = true;
            meshAgent.enabled = true;
            specificChildCollider.enabled = true;
            CurrentHealth = maxHealth;
            OnDamaged?.Invoke(CurrentHealth, maxHealth);
            respawner.RespawnEnemy(gameObject, time2);
        }
    }
    private void OnDisable()
    {
        
    }
}
