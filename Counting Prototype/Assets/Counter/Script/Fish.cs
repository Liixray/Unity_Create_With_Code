using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fish : MonoBehaviour
{

    public int score;
    private Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotation*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
