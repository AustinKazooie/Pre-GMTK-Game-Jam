using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tricks2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpHeight;
    private Vector2 lastBodyVelocity;
    private Rigidbody2D body;
    private bool grounded;
    private bool inAir;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (body.velocity.x != 0)
        {
            lastBodyVelocity = body.velocity;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(MathF.Abs(transform.localScale.x), transform.localScale.y, 1);
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
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-MathF.Abs(transform.localScale.x), transform.localScale.y, 1);
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
            Jump();
        }
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        grounded = false;
        inAir = true;
        StartCoroutine(CheckAirTricks());
    }

    private IEnumerator CheckAirTricks()
    {
        while (inAir)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    Debug.Log("Christ Air");
                }
                else
                {
                    Debug.Log("Kickflip");
                }
            }
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                Debug.Log("Tailflip");
            }

            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("SackTap");
            }


            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
            inAir = false;
    }
}
