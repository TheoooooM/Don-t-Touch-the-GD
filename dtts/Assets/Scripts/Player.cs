using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("==== Player Stats ====")] 
    [SerializeField] float jumpForce = 5; 
    [SerializeField] float speed = 5;
    [SerializeField] private float maxForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up*jumpForce;
        }

        if (rb.velocity.y > maxForce) rb.velocity = new Vector2(rb.velocity.x, maxForce);
        else if (rb.velocity.y < -maxForce)rb.velocity = new Vector2(rb.velocity.x, -maxForce);
    }
}
