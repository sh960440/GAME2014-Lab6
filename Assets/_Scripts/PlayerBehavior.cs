using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Joystick jojstick;
    public float JoystickSensitivity;
    public float horizontalForce;
    public float jumpForce;
    public float maximumVelocituX;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // _Move();
        this._Move(); 
    }

    private void _Move()
    {
        if (jojstick.Horizontal > JoystickSensitivity)
        {
            rigidbody.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
        }

        if (jojstick.Horizontal < -JoystickSensitivity)
        {
            rigidbody.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
        }
    }
}
