using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidBody;

    public bool canJump;

    float jumpForce = 15;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(rigidBody.velocity.y == 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (canJump && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    
}

