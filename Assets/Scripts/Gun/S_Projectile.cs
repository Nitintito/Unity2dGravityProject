using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 gravityDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        gravityDirection = S_2DCustomGravity.GetGravity(rb.position);
        rb.AddForce(gravityDirection);
    }
}
