using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 30;
    [SerializeField] private float dashForce = 30;
    public float startFule = 3;
    [SerializeField] private float dashFuleCost = 1.5f;
    [SerializeField] private float rotationSpeed = 5;

    [HideInInspector] public float currentFule; 

    private bool requestMove;
    private bool requestDash;

    private float horizontalInput, verticalInput;

    Vector2 gravityDirection;
    Vector2 upAxis;

    private Rigidbody2D rb;
    S_FuleUi fuleUi;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fuleUi = FindObjectOfType<S_FuleUi>();
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
        RequestedInput();
    }

    private void Rotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.forward, upAxis), rotationSpeed * Time.deltaTime); //transfrom.rotate in the direction of forwardAxis
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

    private void Movement(float currentFule, bool dash)
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (currentFule > 0)
        {
            if (!dash)
            {
                float movementDirectionHorizontal = horizontalInput * movementSpeed;
                float movementDirectionVertical = verticalInput * movementSpeed;

                Vector2 movementVector = new Vector2(movementDirectionHorizontal, movementDirectionVertical);

                rb.AddForce(movementVector);
            }
            else
            {
                float movementDirectionHorizontal = horizontalInput * dashForce;
                float movementDirectionVertical = verticalInput * dashForce;

                Vector2 dashVector = new Vector2(movementDirectionHorizontal, movementDirectionVertical);

                rb.AddForce(dashVector, ForceMode2D.Impulse);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
            S_UiManager.levelFaild = true;
        }
    }

    private void RequestedInput()
    {
        if (requestMove)
        {
            Movement(currentFule, false);
        }

        if (requestDash)
        {
            requestDash = false;
            Movement(currentFule, true);
            currentFule -= dashFuleCost;
        }
    }

    private void CheckForInput()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            requestMove = true;
        else
            requestMove = false;

        if (Input.GetButtonDown("Dash"))
            requestDash = true;
    }
}
