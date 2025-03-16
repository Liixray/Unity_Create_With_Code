using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 60.0f;

    private float horizontalInput;
    private float forwardInput;

    public string horizontalKey;
    public string verticalKey;
    public string switchCamera;

    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis(horizontalKey);
        forwardInput = Input.GetAxis(verticalKey);

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Rotates the car forward based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        
        if (Input.GetKeyDown(switchCamera))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}
