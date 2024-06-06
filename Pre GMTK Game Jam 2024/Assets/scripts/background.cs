using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background: MonoBehaviour
{
    public Rigidbody2D body;
    public Rigidbody2D playerBody;
    public float speed;
    private void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        body.velocity = new Vector2(playerBody.velocity.x * speed/10, body.velocity.y);
    }



}
