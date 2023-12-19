using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovementNew playerMovement;
    private Animator animator;
    public List<GameObject> InventoruList;
    public EnergySystem energySystem;
    private bool isShooting = false;
    private bool isBlocking = false;
    public int aimLayer = 1;
    public int attackLayer = 2;
    private float mousYSum = 0.0f;
    public float sensitivity = 2.0f;
    private float mouseYSum = 0.0f;
    public float maxYAngle = 30.0f;
    public float minYAngle = -30.0f;
    private int EnergyShot = 20;
    private int EnergyBlock = 20;
    private int EnergyAttack = 20;
    
    private void Start()
    {
        
        playerMovement = GetComponent<PlayerMovementNew>();
        animator = GetComponent<Animator>();  
        
    }

    private void Update()
    {
        var energy = gameObject.GetComponent<EnergySystem>();
        Vector2 movementInput = InputService.Instance.MovementInput;
       // Vector2 mouseInput = InputService.Instance.MouseInput;
      
       // mousYSum += mouseInput.y * sensitivity;
       // mouseYSum = Mathf.Clamp(mouseYSum + mouseInput.y, minYAngle, maxYAngle);
        
        //animator.SetFloat("Aim",mouseYSum);
        animator.SetFloat("inputX", movementInput.x);
        animator.SetFloat("inputY", movementInput.y);
        //Debug.Log("Mouse Y: " + mouseInput.y);
        

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
            if (Input.GetButtonDown("Fire1") && !isShooting)
            {
                // isShooting = true;
                animator.SetTrigger("Attack");
                // animator.SetLayerWeight(aimLayer, 1f);
                energy.Actions(EnergyAttack);
            }
        }
        
        
        if (energy != null && energy.CurrentEnergy >= EnergyBlock)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && !isBlocking )
            {
                isBlocking  = true;
                animator.SetBool("Block", true);
                energy.Actions(EnergyBlock);
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse1) && isBlocking )
        {
            isBlocking  = false;
            animator.SetBool("Block",false);
                
        }
 
        if (energy != null && energy.CurrentEnergy >= EnergyShot)
        {
            if (InputService.Instance.Shot)
            {
                animator.SetTrigger("Shot");
                energy.Actions(EnergyShot);
                // animator.SetLayerWeight(aimLayer, 1f);
            }
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
    
