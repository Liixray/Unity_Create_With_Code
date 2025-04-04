﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh text;
    public ParticleSystem sparksParticles;
    
    private List<string> textToDisplay = new List<string>();
    
    private float rotatingSpeed;
    private float timeToNextText;

    private int currentText;
    
    // Start is called before the first frame update
    void Start()
    {
        timeToNextText = 0.0f;
        currentText = 0;
        
        rotatingSpeed = 5.0f;

        textToDisplay.Add("Congratulation");
        textToDisplay.Add("All Errors Fixed");

        text.text = textToDisplay[0];
        
        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        text.transform.Rotate(0, rotatingSpeed * Time.deltaTime, 0);
        timeToNextText += Time.deltaTime;

        if (timeToNextText > 1.5f)
        {
            timeToNextText = 0.0f;
            
            currentText++;
            if (currentText >= textToDisplay.Count)
            {
                currentText = 0;
            }

            text.text = textToDisplay[currentText];
        }
    }
}