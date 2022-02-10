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
        if (GameManager.Instance.currentGameState == GameManager.GameState.inGame)
        {
            
            rb.simulated = true;
            transform.Translate(speed, 0, 0);
        }
        else
        {
            rb.simulated = false;
            Debug.Log("not in game");
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up*jumpForce;
            if (GameManager.Instance.currentGameState == GameManager.GameState.menu) GameManager.Instance.currentGameState = GameManager.GameState.inGame;
        }

        if (rb.velocity.y > maxForce) rb.velocity = new Vector2(rb.velocity.x, maxForce);
        else if (rb.velocity.y < -maxForce)rb.velocity = new Vector2(rb.velocity.x, -maxForce);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.inGame)
        {
            rb.simulated = true;
            transform.Translate(speed, 0, 0);
        }
        else
        {
            rb.simulated = false;
            Debug.Log("not in game");
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Walls"))
        {
            Debug.Log("reverse sens");
            speed = -speed;
        }
    }
}
