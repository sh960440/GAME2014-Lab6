﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Joystick jojstick;
    public float JoystickHorizontalSensitivity;
    public float JoystickVerticalSensitivity;
    public float horizontalForce;
    public float jumpForce;
    public float maximumVelocityX;
    public bool isGrounded;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // _Move();
        this._Move(); 
    }

    private void _Move()
    {
        if (isGrounded)
        {
            if (jojstick.Horizontal > JoystickHorizontalSensitivity)
        {
            rigidbody.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = false;
            animator.SetInteger("AnimState", 1);
        }

        else if (jojstick.Horizontal < -JoystickHorizontalSensitivity)
        {
            rigidbody.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            spriteRenderer.flipX = true;
            animator.SetInteger("AnimState", 1);
        }
        else if (jojstick.Vertical > JoystickVerticalSensitivity)
        {
            rigidbody.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            animator.SetInteger("AnimState", 2);
        }

        else
        {
            animator.SetInteger("AnimState", 0);
        }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
