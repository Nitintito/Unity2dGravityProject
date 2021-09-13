using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_GolfBall : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         
    }

    private void FixedUpdate()
    {
        
    }

    private void CheckInputs()
    {

    }

    private void DragShoot()
    {

    }
}
