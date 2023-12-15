using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    
    [SerializeField] private string[] _damageTag;
    [SerializeField] private int damage;


    private void OnTriggerEnter(Collider other)
    {
        foreach (var tag in _damageTag)
        {
            if (other.gameObject.CompareTag(tag))
            {
                var health = other.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.Damage(damage);
                    //gameObject.SetActive(false);
                }
            }
        }
    }
}
