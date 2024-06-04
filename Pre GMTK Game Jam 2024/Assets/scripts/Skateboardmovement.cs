using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboardmovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    private bool inAir;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (grounded)
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        if (horizontalInput < 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) &&  grounded)
            Jump();

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
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
                Debug.Log("Kickflip");
                if (Input.GetKey(KeyCode.S))
                {
                    Debug.Log("Christ Air");
                }
                else
                {
                    Debug.Log("Kickflip");
                }
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
