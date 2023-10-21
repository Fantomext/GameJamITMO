using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerContorller : MonoBehaviour
{
    public float speed = 5f;
    public float gazonSpeed;
    public float steering = 5f;
    public float maxSpeed = 10f;
    public float jumpForce = 5f;
    public float boostMultiplier = 2f;
    public float slopeTiltAngle = 15f;
    public LayerMask groundLayer;
    public LayerMask gazonLayerMask;

    public float speedReload;
    public float nitroAmount = 1f;

    public Transform raycast;
    
    public Transform frontWheel;
    public Transform backWheel;
    public Transform ryl;

    private Rigidbody rb;
    public bool isGrounded;
    public bool isGazon;
    public bool isNitro;
    public bool havePils;

    public float currentAcceleration;


    public float wheelRotationSpeed = 360f;

    [SerializeField] private float _friction;


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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isNitro = true;
        }
    }


    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(raycast.position, -Vector3.up, 0.5f, groundLayer);
        isGazon = Physics.Raycast(raycast.position, -Vector3.up, 0.5f, gazonLayerMask);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ApplyVisualRotation(moveHorizontal);

        currentAcceleration = isGazon? gazonSpeed : speed;

        Vector3 forwardForce = transform.forward * moveVertical * currentAcceleration;
        float turnAngle = moveHorizontal * steering * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAngle, 0f);

        if (isNitro)
        {
            rb.AddForce(forwardForce * boostMultiplier, ForceMode.Force);
            isNitro = false;
        }

        RotateWheels(moveVertical);

        rb.AddForce(forwardForce, ForceMode.Acceleration);
        rb.MoveRotation(rb.rotation * turnRotation);

        rb.AddForce(-rb.velocity.x * _friction, 0f, 0f);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        //if (rb.velocity.magnitude > maxSpeed)
        //{
        //    rb.velocity = rb.velocity.normalized * maxSpeed;
        //}
    }

    private void ApplyVisualRotation(float rotation)
    {
        if(rotation!=0)
        {
            frontWheel.transform.localRotation = Quaternion.Euler(0, rotation * 40,0 );
            ryl.transform.localRotation = Quaternion.Euler(-90, rotation * 40,180 );
        }
        else
        {
            frontWheel.transform.localRotation = Quaternion.Euler(0, 0, 0);
            ryl.transform.localRotation = Quaternion.Euler(-90, 0 , 180);
        }
    }

    private void RotateWheels(float moveVertical)
    {
        float rotationAngle = moveVertical * wheelRotationSpeed * Time.deltaTime;
        frontWheel.Rotate(Vector3.forward, rotationAngle);
        backWheel.Rotate(Vector3.forward, rotationAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pils"))
        {
            havePils = true;
        }

    }
}


