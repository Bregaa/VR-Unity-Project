using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittentLightFromSparks : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public GameObject lampRack;
    private int particlesCount;
    private int particlesCountPrevious;

    private GameObject lampOn;
    private GameObject lampOff;
    private bool powerOn;

    void Start()
    {
        particlesCount = 0;
        particlesCountPrevious = 0;
        lampOn = lampRack.transform.Find("LampOn").gameObject;
        lampOff = lampRack.transform.Find("LampOff").gameObject;
        powerOn = false;
    }

    void Update()
    {
        if(powerOn) {
            particlesCountPrevious = particlesCount;
            particlesCount = particleSystem.particleCount;
            if (particlesCount < 20)
            {
                lampOn.SetActive(true);
                lampOff.SetActive(false);
            }
            else
            {
                lampOn.SetActive(false);
                lampOff.SetActive(true);
            }
        }
        else
        {
            if (lampOn.activeSelf)
            {
                powerOn = true;
            }
        }
    }
}
