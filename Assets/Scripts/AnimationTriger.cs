using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriger : MonoBehaviour
{
    public Collider targetCollider;

    
    private IEnumerator ActivateColliderAfterDelay()
    {
  
        targetCollider.enabled = true;

        yield return new WaitForSeconds(0.5f);

        targetCollider.enabled = false;
    }
}
