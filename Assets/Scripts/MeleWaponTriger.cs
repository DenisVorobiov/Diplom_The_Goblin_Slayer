using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWaponTriger : MonoBehaviour
{
    public Collider meleWaponCollider;

    
    private IEnumerator ActivateColliderAfterDelay()
    {
  
        meleWaponCollider.enabled = true;

        yield return new WaitForSeconds(0.5f);

        meleWaponCollider.enabled = false;
    }
}
