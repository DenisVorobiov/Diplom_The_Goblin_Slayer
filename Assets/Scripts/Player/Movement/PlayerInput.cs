using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovementNew playerMovement;
    private Animator animator;
    public GameObject Inventoru;
    private bool isShooting = false;
    

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementNew>();
        animator = GetComponent<Animator>();  
    }

    private void Update()
    {
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

        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            isShooting = true;
            animator.SetBool("IsShooting", true);
           
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            animator.SetBool("IsShooting", false);
        }

        /*if (InputService.Instance.Inventory)
        {
            Inventoru.SetActive(!Inventoru.activeSelf);
            Cursor.visible =! Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }*/

    }
}