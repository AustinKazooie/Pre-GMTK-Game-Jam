using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background: MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

    }



}
