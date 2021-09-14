using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 30;
    public float startFule = 3;
    [HideInInspector] public float currentFule; 
    [SerializeField] private float jumpForce = 30;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private float dashForce = 30;

    private bool requestMove;
    private bool requestJump;
    private bool requestDash;

    Vector2 gravityDirection;
    Vector2 upAxis;
    Vector2 velocity;

    private Rigidbody2D rb;

    [SerializeField] private S_FuleUi fuleUi;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        S_UiManager.levelFaild = false;
        rb.gravityScale = 0;
    }

    private void Start()
    {
        currentFule = startFule;
        fuleUi.SetMaxFule(currentFule);
    }

    private void Update()
    {
        CheckForInput();
        UpdateFule();
    }

    private void FixedUpdate()
    {
        Gravity();
        Rotation();

        if (requestMove)
        {
            Move(currentFule);
        }
        if (requestJump /*and not in air*/)
        {
            requestJump = false;
            Jump();
        }
        if (requestDash)
        {
            requestDash = false;
            Dash();
        }
    }

    private void Gravity()
    {
        upAxis = -Physics2D.gravity.normalized;
        gravityDirection = S_2DCustomGravity.GetGravity(rb.position, out upAxis);

        if (upAxis.x != 0 || upAxis.y != 0)
        {
            rb.AddForce(gravityDirection);
        }
        else
        {
            rb.AddForce(Physics2D.gravity);
            upAxis = -Physics2D.gravity.normalized; // this needs to be her idk why it dose not work
        }
    }

    private void UpdateFule()
    {
        fuleUi.SetFule(currentFule);

        if (requestMove && currentFule > 0)
        {
            currentFule -= Time.deltaTime;
        }
    }

    private void Move(float fule)
    {
        if (fule > 0)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            float movementDirectionHorizontal = horizontalInput * movementSpeed;
            float movementDirectionVertical = verticalInput * movementSpeed;

            Vector2 movementVector = new Vector2(movementDirectionHorizontal, movementDirectionVertical);

            rb.AddForce(movementVector);
        }
    }

    private void Rotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.forward, upAxis), rotationSpeed * Time.deltaTime); //transfrom.rotate in the direction of forwardAxis
    }

    private void Jump()
    {
        Vector2 jumpDirection = upAxis * jumpForce;
        rb.AddForce(jumpDirection, ForceMode2D.Impulse);
    }

    private void Dash()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float dashDirection = horizontalInput * dashForce;
        Vector2 dashVector = new Vector2(dashDirection, 0);

        rb.AddForce(dashVector, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
            S_UiManager.levelFaild = true;
        }
    }

    private void CheckForInput()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            requestMove = true;
        else
            requestMove = false;

        if (Input.GetButtonDown("Jump"))
            requestJump = true;
    }
}
