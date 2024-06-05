using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NikiScateboardScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float keepMomentumPercantage;
    private Vector2 lastBodyVelocity;
    private Rigidbody2D body;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (body.velocity.x !=0)
        {
            lastBodyVelocity = body.velocity;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
            }
            else
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            }
            if (body.velocity.x < 0 && grounded)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }
            else
            {
                if (grounded)
                    body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
            }
            if (body.velocity.x > 0 && grounded)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }
            else
            {
                if (grounded)
                    body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
            }
        }
        if (Input.GetKey(jumpKey) && grounded)
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(keepMomentumPercantage*lastBodyVelocity.x/100, body.velocity.y);
            }
                Jump();
        }
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
