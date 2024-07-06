using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class PlaySound : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    private int particlesCount;
    private int particlesCountPrevious;
    private System.Random random = new System.Random();
    private int randomNumber;

    void Start()
    {
        particlesCount = 0;
        particlesCountPrevious = 0;
    }

    
    void Update()
    {
        particlesCountPrevious = particlesCount;
        particlesCount = particleSystem.particleCount;
        if(particlesCountPrevious < particlesCount)
        {
            randomNumber = random.Next(0, 2);
            if(particlesCount - particlesCountPrevious <= 10)
            {
                switch (randomNumber)
                {
                    case 0:
                        audioSource1.Play();
                        //Debug.Log(particleSystem.particleCount - particlesCount + " audioSource1");
                        break;
                    case 1:
                        audioSource2.Play();
                        //Debug.Log(particleSystem.particleCount - particlesCount + " audioSource2");
                        break;
                }
            }
            else
            {
                switch (randomNumber)
                {
                    case 0:
                        audioSource3.Play();
                        //Debug.Log(particleSystem.particleCount - particlesCount + " audioSource3");
                        break;
                    case 1:
                        audioSource4.Play();
                        //Debug.Log(particleSystem.particleCount - particlesCount + " audioSource4");
                        break;
                }
            }
                
                
        }
    }
}
