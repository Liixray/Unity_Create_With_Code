using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower = 20.0f;
    [SerializeField] float turnSpeed = 60.0f;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    public string horizontalKey;
    public string verticalKey;
    public string switchCamera;

    public Camera camera1;
    public Camera camera2;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis(horizontalKey);
        forwardInput = Input.GetAxis(verticalKey);

        if (IsOnGround())
        {
            // Moves the car forward based on vertical input
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            // Rotates the car forward based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + "kph");
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }

        if (Input.GetKeyDown(switchCamera))
        {
            Debug.Log("SWITCH");
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        int i = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            i++;
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround >1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
