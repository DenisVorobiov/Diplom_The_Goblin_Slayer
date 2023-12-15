using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovementNew playerMovement;
    private Animator animator;
    public List<GameObject> InventoruList;
    private bool isShooting = false;
    public int aimLayer = 1;
    public int attackLayer = 2;
    private float mousYSum = 0.0f;
    public float sensitivity = 2.0f;
    private float mouseYSum = 0.0f;
    public float maxYAngle = 30.0f;
    public float minYAngle = -30.0f;

    private void Start()
    {
        
        playerMovement = GetComponent<PlayerMovementNew>();
        animator = GetComponent<Animator>();  
    }

    private void Update()
    {
        Vector2 movementInput = InputService.Instance.MovementInput;
        Vector2 mouseInput = InputService.Instance.MouseInput;
      
        mousYSum += mouseInput.y * sensitivity;
        mouseYSum = Mathf.Clamp(mouseYSum + mouseInput.y, minYAngle, maxYAngle);
        
        animator.SetFloat("Aim",mouseYSum);
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

        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            isShooting = true;
            animator.SetBool("IsShooting", true);
            animator.SetLayerWeight(aimLayer, 1f);
            animator.SetLayerWeight(attackLayer, 1f);
        }

        if (Input.GetButtonUp("Fire1")&& isShooting)
        {
            isShooting = false;
            animator.SetBool("IsShooting", false);
            animator.SetLayerWeight(aimLayer, 0f);
            animator.SetLayerWeight(attackLayer, 0f);
            
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
    
