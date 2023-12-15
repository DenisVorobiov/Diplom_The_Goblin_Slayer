using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
   [SerializeField] public int maxHealth;
    public Collider specificChildCollider;
    public Animator animator;
    public Collider coliderObj;
    public NavMeshAgent meshAgent;
   
    public int CurrentHealth { get; private set; }
    public event Action<int, int> OnDamaged;
    public event Action OnAddGold;
    
    [SerializeField] public float time;
    [SerializeField] public float time2;

    public void SetHealth(int newHealth)
    {
        CurrentHealth = newHealth;
        maxHealth = newHealth;
    }

   public void Damage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
            OnDie();
        OnDamaged?.Invoke(CurrentHealth,maxHealth);
    }
    private void OnDie()
    {
        Debug.Log("OnDie called");
        if (tag != "Player")
    
            Context.Instance.ScoreSystem.AddScore(100);
            
            OnAddGold?.Invoke();
                //specificChildCollider.enabled = false;
                animator.enabled = false;
                //coliderObj.enabled = false;
                meshAgent.enabled = false;
                //scriptOnOtherObject.enabled = false;

               // StartCoroutine(DisableRoutine());
          
    }
    
    private IEnumerator DisableRoutine()
    {
        Debug.Log("DisableRoutine started");
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        
    }
    public void Respawn()
    {
        Debug.Log("Respawn called");
        Respawn respawner = FindObjectOfType<Respawn>();
        if (respawner != null)
        {
            animator.enabled = true;
            meshAgent.enabled = true;
            //scriptOnOtherObject.enabled = true;
            CurrentHealth = maxHealth;
            OnDamaged?.Invoke(CurrentHealth, maxHealth);
            respawner.RespawnEnemy(gameObject, time2);
           
        }
    }

    private void OnDisable()
    {

        Respawn();
    }
}
