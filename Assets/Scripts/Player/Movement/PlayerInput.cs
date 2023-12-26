using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   
    private PlayerMovementNew playerMovement;
    private Animator animator;
    public List<GameObject> InventoruList;
    private Health playerHealth;
    private Recovery _recovery;
    
    public bool isWeaponSlotEmpty = true;
    public bool isDaggerSlotEmpty = true;
    public bool isShieldSlotEmpty = true;
    public bool isHpdSlotEmpty = true;
    private bool isShooting = false;
    private bool isBlocking = false;
    
    private int EnergyShot = 20;
    private int EnergyBlock = 20;
    private int EnergyAttack = 20;
    
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementNew>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<Health>();
        _recovery = GetComponent<Recovery>();

    }

    private void Update()
    {
        var energy = gameObject.GetComponent<EnergySystem>();
        //Recovery recovery = gameObject.AddComponent<Recovery>();
        Vector2 movementInput = InputService.Instance.MovementInput;
        
        animator.SetFloat("inputX", movementInput.x);
        animator.SetFloat("inputY", movementInput.y);
        
        if (InputService.Instance.JumpInput)
        {
            if(playerMovement.grounded && playerMovement.readyToJump)
            {
                animator.SetTrigger("Jump");
            }

            playerMovement.HandleJumpInput();
        }

        if (energy != null && energy.CurrentEnergy >= EnergyAttack)
        {
            if (Input.GetButtonDown("Fire1")  && !isWeaponSlotEmpty)
            {
               // weaponCollider.enabled = true;
                animator.SetTrigger("Attack");
                energy.Actions(EnergyAttack);
            }
        }
        
        
        if (energy != null && energy.CurrentEnergy >= EnergyBlock)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && !isShieldSlotEmpty)
            {
                playerHealth.RaiseShield();
                isBlocking  = true;
                animator.SetBool("Block", true);
                energy.Actions(EnergyBlock);
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            playerHealth.LowerShield();
            isBlocking  = false;
            animator.SetBool("Block",false);
                
        }
 
        if (energy != null && energy.CurrentEnergy >= EnergyShot)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !isDaggerSlotEmpty) 
            {
                animator.SetTrigger("Shot");
                energy.Actions(EnergyShot);
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.Alpha1)&& !isHpdSlotEmpty)
        {
            _recovery.Use();
        }
        

        if (InputService.Instance.Inventory)
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        foreach (var inventoryObject in InventoruList)
        {
            inventoryObject.SetActive(!inventoryObject.activeSelf);
        }

        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    }

}
    
