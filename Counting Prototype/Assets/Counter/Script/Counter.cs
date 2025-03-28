using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

    public ParticleSystem successParticle;
    public ParticleSystem errorParticle;

    public AudioClip splashSound;
    public AudioClip sucessSound;


    private AudioSource playerAudio;

    private void Start()
    {
        Count = 0;
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            int score = other.GetComponent<Fish>().score;
            if (score > 0) {
                successParticle.Play();
                playerAudio.PlayOneShot(sucessSound,0.25f);
            }
            else
            {
                errorParticle.Play();
                playerAudio.PlayOneShot(splashSound, 0.5f);
            }
                Count += score;
            CounterText.text = "Score : " + Count;
            Destroy(other.gameObject);
        }
    }
}
