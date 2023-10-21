using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerContorller : MonoBehaviour
{
    public float acceleration = 5f;
    public float steering = 5f;
    public float maxSpeed = 10f;
    public float jumpForce = 5f;
    public float boostMultiplier = 2f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.2f, groundLayer);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float currentAcceleration = acceleration;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentAcceleration *= boostMultiplier;
        }

       

        Vector3 forwardForce = transform.forward * moveVertical * currentAcceleration;
        float turnAngle = moveHorizontal * steering * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAngle, 0f);

        if (isGrounded)
        {
            rb.AddForce(forwardForce, ForceMode.Acceleration);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // Limit the scooter's speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}


