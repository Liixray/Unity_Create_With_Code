using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private CharacterController characterController;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            characterController.Move(move * Time.deltaTime * speed);
            playerRb.transform.rotation = Quaternion.LookRotation(move, Vector3.up);
        }
        //missileRb.transform.position += movementDirection * speed * Time.deltaTime;
    }
}
