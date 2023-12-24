using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{

    public static InputService Instance { get; private set; }
    public Vector2 MovementInput { get; private set; }
    public bool Fire {  get; private set; }
    public bool Inventory {  get; private set; }
    public Vector2 MouseInput { get; private set; }
    public bool JumpInput { get; private set; } 
    public bool Shot { get; private set; }
    public bool Block { get; private set; }
    
    public bool InteractivKey { get; private set; }
   
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
        float verticalM = Input.GetAxisRaw("Mouse Y");
        float horizontalM = Input.GetAxisRaw("Mouse X");
        MouseInput = new Vector2(horizontalM, verticalM);
        MovementInput = new Vector2(horizontal, vertical);
        JumpInput = Input.GetKeyDown(KeyCode.Space);
       
        Block = Input.GetKeyDown(KeyCode.Mouse1);
        //Attack
        Fire = Input.GetButtonDown("Fire1");
       // Shot = Input.GetKeyDown(KeyCode.Q);
        //UI
        Inventory = Input.GetKeyDown(KeyCode.I);
        
        //Interactiv
        InteractivKey = Input.GetKeyDown(KeyCode.E);

    }
}