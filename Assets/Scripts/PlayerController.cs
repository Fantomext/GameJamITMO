using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform centerMass;
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float breakForce;
    public float maxSpeed;
    public float jumpForce;
    public LayerMask groundLayer;


    private Rigidbody rb;

    private float currentBreakForce;
    private bool isBreaking;
    private bool isJumping;
    private bool isGrounded;


    private void ApplyVisual(WheelCollider collider, GameObject wheelVisual)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

       // wheelVisual.transform.position = position;

        
        wheelVisual.transform.rotation = Quaternion.Euler(rotation.x,rotation.y, rotation.z);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = centerMass.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakForce;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentBreakForce = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            isJumping = true;
        }
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.2f, groundLayer);

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }

        foreach (AxleInfo axleInfo in axleInfos) 
        {

            axleInfo.Wheel.brakeTorque = currentBreakForce;
            if (axleInfo.steering)
            {

                axleInfo.Wheel.steerAngle = steering;
                

            }
            if (axleInfo.motor)
            {
                axleInfo.Wheel.motorTorque = motor;
                //axleInfo.Wheel.brakeTorque = currentBreakForce;
            }

            ApplyVisual(axleInfo.Wheel,axleInfo.Visual);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            Debug.Log("MAX SPEED");
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

   
}

[Serializable]
public class AxleInfo
{
    public WheelCollider Wheel;
    public GameObject Visual;
    public bool motor;
    public bool steering;
}


