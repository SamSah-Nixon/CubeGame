using Unity.VisualScripting;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("World")] public GameObject canvas;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {

        
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        MyInput();
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        MovePlayer();
    }

    private void MovePlayer()
    {


        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // rotate physical body
        transform.rotation = orientation.rotation;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 500f * Time.deltaTime, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 500f * airMultiplier * Time.deltaTime, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            canvas.GetComponent<DeathScreen>().Death(collision.gameObject.name);
        }
    }
}