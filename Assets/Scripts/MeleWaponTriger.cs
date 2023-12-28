using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWaponTriger : MonoBehaviour
{
    [SerializeField] private GameObject weaponObject;
    [SerializeField] private PlayerInput _isWeaponSlotEmpty;
    
    private Collider _collider;
    private void Awake()
    {
        UpdateWeaponColliderReference();
    }
    
    public IEnumerator ActivateColliderAfterDelay()
    {
        if (_collider != null)
        {
            _collider.enabled = true;
                yield return new WaitForSeconds(0.5f);
                     _collider.enabled = false;
        }
    }
    public void UpdateWeaponColliderReference()
    {
        if (_collider != null)
            return;

        _collider = weaponObject?.GetComponentInChildren<Collider>(true);

        if (_collider == null)
            Debug.LogWarning("Collider not found on the weapon object or its children.");
        
        _isWeaponSlotEmpty.isWeaponSlotEmpty = (_collider != null);
    }
}
