using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementNew : MonoBehaviour
{
    [SerializeField] private PlayerStatsStorage stats;
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
           
            Invoke(nameof(ResetJump), stats.jumpCooldown);

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
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (grounded)
        {
            rb.drag = stats.groundDrag;
            rb.AddForce(moveDirection.normalized * stats.moveSpeed * stats.multiplication, ForceMode.Force);
        }
        else
        {
            rb.drag = 0;
            rb.AddForce(moveDirection.normalized * stats.moveSpeed * stats.multiplication * stats.airMultiplier, ForceMode.Force);
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * stats.jumpForce, ForceMode.Impulse);
        readyToJump = false;
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void Grounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, stats.playerHeight * stats.playerPercentage + stats.playerPercentagePlus, whatIsGround);
    }
    
}