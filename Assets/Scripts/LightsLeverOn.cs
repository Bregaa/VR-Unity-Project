using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using System.Xml;

public class LightsLeverOn : MonoBehaviour
{
    private GameObject lever;
    private Rigidbody leverRigidbody;
    private CapsuleCollider knobCollider;
    private bool areLightsOn;
    private GameObject fuseBox;
    private float rotationX;
    private float addedRotation;

    private GameObject pilar1;
    private GameObject pilar2;
    private GameObject pilar3;
    private GameObject pilar4;

    void Start()
    {
        lever = this.gameObject; //Gets the GameObject the script is attached to (Lever)
        areLightsOn = false;
        fuseBox = GameObject.Find("Fuse Box");

        pilar1 = GameObject.Find("Pilar1");
        pilar2 = GameObject.Find("Pilar2");
        pilar3 = GameObject.Find("Pilar3");
        pilar4 = GameObject.Find("Pilar4");

        //This is necessary to not cause a stutter when the lever turns the lights on
        //I believe it's caused by the length of the audio files to be played, it takes
        //too long to load them up, and that causes the stutter.
        startAndPauseAudio();
    }

    void Update()
    {
        if ((!areLightsOn))
        {
            //Moves the volt arrow
            rotationX = lever.transform.localRotation.eulerAngles.x;
            
            if (rotationX < 39) addedRotation = 38 - rotationX;
            else addedRotation = 360 - rotationX + 38;
            Vector3 voltArrowRotation = fuseBox.transform.Find("ArrowVolt").localRotation.eulerAngles;
            voltArrowRotation.y = (addedRotation - 60) * 0.75f;
            fuseBox.transform.Find("ArrowVolt").localRotation = Quaternion.Euler(voltArrowRotation);


            if (rotationX < 280 && rotationX > 40)
            {
                areLightsOn = true;
                //Locks the lever
                leverRigidbody = lever.GetComponent<Rigidbody>();
                leverRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
                //Plays fuse box transformer noise
                AudioSource[] audioSources = lever.GetComponents<AudioSource>();
                foreach (AudioSource audioSource in audioSources)
                {
                    audioSource.Play();
                }
                //Changes green/red lights on the fuse box
                fuseBox.transform.Find("Lamp 1 on").gameObject.SetActive(true);
                fuseBox.transform.Find("Lamp 1 off").gameObject.SetActive(false);
                fuseBox.transform.Find("Lamp 2 on").gameObject.SetActive(false);
                fuseBox.transform.Find("Lamp 2 off").gameObject.SetActive(true);

                //Turns on the lamps and plays the effects/noises
                pilar2.transform.Find("Invisible Barrier").gameObject.SetActive(false);
                turnOnLampPilar(pilar1);
                turnOnLampPilar(pilar2);
                turnOnLampPilar(pilar3);
                GameObject pilarLampRack = pilar4.transform.Find("LampRack")?.gameObject;
                pilarLampRack.transform.Find("LampOn")?.gameObject.SetActive(true);
                pilarLampRack.transform.Find("LampOff")?.gameObject.SetActive(false);
                pilarLampRack.GetComponent<AudioSource>().Play();
                GameObject pilarSparksOnCommand = pilar4.transform.Find("Sparks intermittent")?.gameObject;
                pilarSparksOnCommand.SetActive(true);

                GameObject.Find("4 - That's on").GetComponent<AudioSource>().Play();
                GameObject.Find("Canvas").GetComponent<ChangeCanvasInstruction>().changeCanvasPanel();
            }
        }
    }

    public void DisableInteractableFuseBoxLever()
    {
        if (areLightsOn)
        {
            knobCollider = lever.transform.Find("Knob")?.gameObject.GetComponent<CapsuleCollider>();
            knobCollider.enabled = false;
        }
    }

    private void turnOnLampPilar(GameObject pilar)
    {
        GameObject pilarLampRack = pilar.transform.Find("LampRack")?.gameObject;
        pilarLampRack.transform.Find("LampOn")?.gameObject.SetActive(true);
        pilarLampRack.transform.Find("LampOff")?.gameObject.SetActive(false);
        pilarLampRack.GetComponent<AudioSource>().Play();
        GameObject pilarSparksOnCommand = pilar.transform.Find("Sparks on command")?.gameObject;
        pilarSparksOnCommand.transform.Find("Sparks Particle System")?.gameObject.GetComponent<ParticleSystem>().Play();
        AudioSource pilarAudioSource = pilarSparksOnCommand.transform.Find("Audio Source Zap4")?.gameObject.GetComponent<AudioSource>();
        pilarAudioSource.Play();
    }
    private void startAndPauseAudio()
    {
        GameObject pilarLampRack = pilar1.transform.Find("LampRack")?.gameObject;
        pilarLampRack.GetComponent<AudioSource>().Play();
        pilarLampRack.GetComponent<AudioSource>().Pause();
        pilarLampRack = pilar2.transform.Find("LampRack")?.gameObject;
        pilarLampRack.GetComponent<AudioSource>().Play();
        pilarLampRack.GetComponent<AudioSource>().Pause();
        pilarLampRack = pilar3.transform.Find("LampRack")?.gameObject;
        pilarLampRack.GetComponent<AudioSource>().Play();
        pilarLampRack.GetComponent<AudioSource>().Pause();
        pilarLampRack = pilar4.transform.Find("LampRack")?.gameObject;
        pilarLampRack.GetComponent<AudioSource>().Play();
        pilarLampRack.GetComponent<AudioSource>().Pause();
    }
}
