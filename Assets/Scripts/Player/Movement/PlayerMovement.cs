using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementNew : MonoBehaviour
{
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float playerHeight;

    private float multiplication = 10;
    private float playerPercentage = 0.2f;
    private float playerPercentagePlus = 0.3f;

    public LayerMask whatIsGround;
    public Transform orientation;
    public Rigidbody rb { get; set; }

    public bool grounded { get; private set; }
    public bool readyToJump { get; private set; }
    // public Vector2 Direction { get; set; } //!

    private void Awake()
    {
        orientation = transform;
    }
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    public void HandleJumpInput()
    {
        if (grounded && readyToJump)
        {
            readyToJump = false;
           
            Invoke(nameof(ResetJump), jumpCooldown);

            Jump();

        }
    }

    private void Update()
    {
        Grounded();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movementInput = InputService.Instance.MovementInput;
        Vector3 moveDirection = orientation.forward * movementInput.y + orientation.right * movementInput.x;
        //Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (grounded)
        {
            rb.drag = groundDrag;
            rb.AddForce(moveDirection.normalized * moveSpeed * multiplication, ForceMode.Force);
        }
        else
        {
            rb.drag = 0;
            rb.AddForce(moveDirection.normalized * moveSpeed * multiplication * airMultiplier, ForceMode.Force);
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        readyToJump = false;
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void Grounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * playerPercentage + playerPercentagePlus, whatIsGround);
    }
    
}