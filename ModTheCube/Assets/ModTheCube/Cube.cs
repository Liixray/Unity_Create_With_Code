using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;


    private float xAngle;
    private float yAngle;
    private float zAngle;

    private float cubeR;
    private float cubeG;
    private float cubeB;
    private float materialOpacity;

    private float cubeRChangingSpeed;
    private float cubeGChangingSpeed;
    private float cubeBChangingSpeed;

    private bool cubeRIsIncreasing;
    private bool cubeGIsIncreasing;
    private bool cubeBIsIncreasing;

    private Material material;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        material = Renderer.material;

        cubeR = Random.Range(0.0f, 1.0f);
        cubeG = Random.Range(0.0f, 1.0f);
        cubeB = Random.Range(0.0f, 1.0f);

        cubeRIsIncreasing = Random.Range(0.0f, 1.0f) > 0.5f ? true : false;
        cubeGIsIncreasing = Random.Range(0.0f, 1.0f) > 0.5f ? true : false;
        cubeBIsIncreasing = Random.Range(0.0f, 1.0f) > 0.5f ? true : false;

        cubeRChangingSpeed = Random.Range(0.0f, 0.5f);
        cubeGChangingSpeed = Random.Range(0.0f, 0.5f);
        cubeBChangingSpeed = Random.Range(0.0f, 0.5f);

        materialOpacity = Random.Range(0.5f, 1.0f);

        material.color = new Color(cubeR, cubeG, cubeB, materialOpacity);

        xAngle = Random.Range(0, 30);
        yAngle = Random.Range(0, 30);
        zAngle = Random.Range(0, 30);
    }
    
    void Update()
    {
        ManageColorValueChange();

        material.color = new Color(cubeR, cubeG, cubeB, materialOpacity);
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime);
    }

    void ManageColorValueChange()
    {
        if (cubeRIsIncreasing)
            cubeR += Time.deltaTime * cubeRChangingSpeed;
        else
            cubeR -= Time.deltaTime * cubeRChangingSpeed;
        if (cubeR <  0.0f)
        {
            cubeR = 0.0f;
            cubeRIsIncreasing = true;
        }
        if (cubeR >= 1.0f)
        {
            cubeR = 1.0f;
            cubeRIsIncreasing = false;
        }

        if (cubeGIsIncreasing)
            cubeG += Time.deltaTime * cubeGChangingSpeed;
        else
            cubeG -= Time.deltaTime * cubeGChangingSpeed;
        if (cubeG < 0.0f)
        {
            cubeG = 0.0f;
            cubeGIsIncreasing = true;
        }
        if (cubeG >= 1.0f)
        {
            cubeG = 1.0f;
            cubeGIsIncreasing = false;
        }

        if (cubeBIsIncreasing)
            cubeB += Time.deltaTime * cubeBChangingSpeed;
        else
            cubeB -= Time.deltaTime * cubeBChangingSpeed;
        if (cubeB < 0.0f)
        {
            cubeB = 0.0f;
            cubeBIsIncreasing = true;
        }
        if (cubeB >= 1.0f)
        {
            cubeB = 1.0f;
            cubeBIsIncreasing = false;
        }



    }
}
