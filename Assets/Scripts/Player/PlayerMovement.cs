using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed;
    public float sprintSpeed;
    float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode pauseKey = KeyCode.Escape;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    [Header("Misc")]
    public Transform orientation;
    [SerializeField] private Levels levels;
    [SerializeField] private GameObject heatPanel;
    private float heat;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

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


        heat -= (Time.deltaTime * 50f);
        if(heat < 0)
            heat = 0;
        heatPanel.GetComponent<Image>().color = new Color(255,0,0,heat/255f);
        if (heat > 255f)
        {
            levels.Death("BURNED");
        }
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

        if (Input.GetKey(sprintKey))
            moveSpeed = sprintSpeed;
        else
            moveSpeed = walkSpeed;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("Fire"))
            heat += 100f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag.Equals("Fire"))
            heat += 5f;
    }
}