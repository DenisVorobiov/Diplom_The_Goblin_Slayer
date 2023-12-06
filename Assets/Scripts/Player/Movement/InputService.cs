using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{

    public static InputService Instance { get; private set; }

    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; } 
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        MovementInput = new Vector2(horizontal, vertical);
        JumpInput = Input.GetKeyDown(KeyCode.Space);

    }
}