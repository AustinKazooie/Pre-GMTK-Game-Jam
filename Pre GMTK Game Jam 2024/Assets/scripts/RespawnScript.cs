using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    private Vector2 spawnPosition;
    private void Start()
    {
        spawnPosition = transform.position;
    }
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = spawnPosition;
        }
    }
}
