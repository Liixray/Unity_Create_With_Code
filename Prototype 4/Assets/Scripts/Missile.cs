using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject target;
    private Rigidbody missileRb;
    private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        missileRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
        }
        Vector3 movementDirection = (target.transform.position - missileRb.transform.position).normalized;

        missileRb.transform.rotation = Quaternion.LookRotation(movementDirection, Vector3.forward);
        missileRb.transform.position += movementDirection*speed*Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromMissile = (collision.gameObject.transform.position - missileRb.transform.position).normalized;

            Destroy(gameObject);
            enemyRigidbody.AddForce(awayFromMissile * 30f, ForceMode.Impulse);
        }
    }
}
