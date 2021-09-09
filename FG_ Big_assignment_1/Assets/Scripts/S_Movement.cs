using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_Movement : MonoBehaviour
{
    public float movementSpeed = 30;
    public float jumpForce = 30;
    public float dashDownForce = 30;
    public float dashForce = 30;
    public float rotationSpeed = 5;


    private bool requestMove;
    private bool requestJump;
    private bool requestDash;
    private bool requestDownDash;


    Vector2 gravityDirection;
    Vector2 upAxis;
    Vector2 velocity;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForInput();
    }

    private void FixedUpdate()
    {
        Gravity();
        Rotation();

        if (requestMove)
        {
            Move();
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
        if (requestDownDash)
        {
            requestDownDash = false;
            DashDown();
        }
    }

    private void Gravity()
    {
        upAxis = -Physics2D.gravity.normalized;
        gravityDirection = S_2DCustomGravity.GetGravity(rb.position, out upAxis);

        if (upAxis.x != 0 || upAxis.y != 0)
        {
            rb.gravityScale = 0;
            rb.AddForce(gravityDirection);
        }
        else
        {
            rb.AddForce(Physics2D.gravity);
            upAxis = -Physics2D.gravity.normalized; // this needs to be her idk why it dose not work
        }

    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float movementDirection = horizontalInput * movementSpeed;
        Vector2 movementVector = new Vector2(movementDirection, 0);

        rb.AddForce(movementVector);
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

    private void DashDown()
    {
        Vector2 direction = -upAxis * jumpForce;
        rb.AddForce(direction, ForceMode2D.Impulse);
    }

    private void Dash()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float dashDirection = horizontalInput * dashForce;
        Vector2 dashVector = new Vector2(dashDirection, 0);

        rb.AddForce(dashVector, ForceMode2D.Impulse);
    }

    private void CheckForInput()
    {
        if (Input.GetAxis("Horizontal") != 0)
            requestMove = true;
        else
            requestMove = false;

        if (Input.GetButtonDown("Jump"))
            requestJump = true;

        if (Input.GetButtonDown("Dash"))
            requestDash = true;

        if (Input.GetButtonDown("Down"))
            requestDownDash = true;
    }
}
