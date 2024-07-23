using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class FlamethrowersGameController : MonoBehaviour
{
    public GameObject flamethrower1;
    public GameObject flamethrower2;
    public GameObject flamethrower3;

    private Animator flamethrower1Animator;
    private Animator flamethrower2Animator;
    private Animator flamethrower3Animator;

    private int roundNumber;

    void Start()
    {
        flamethrower1Animator = flamethrower1.GetComponent<Animator>();
        flamethrower2Animator = flamethrower2.GetComponent<Animator>();
        flamethrower3Animator = flamethrower3.GetComponent<Animator>();

        roundNumber = 0;
    }

    void Update()
    {
        
    }
    
    public void startGame()
    {
        GameObject.Find("Third door").transform.Find("Door").localRotation = Quaternion.Euler(0, 0, 0);
        GameObject.Find("XR Device Simulator").GetComponent<XRDeviceSimulator>().keyboardXTranslateSpeed = 0;
        GameObject.Find("XR Device Simulator").GetComponent<XRDeviceSimulator>().keyboardYTranslateSpeed = 0;
        GameObject.Find("XR Device Simulator").GetComponent<XRDeviceSimulator>().keyboardZTranslateSpeed = 0;
        GameObject.Find("Move").GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
        nextRound();
    }

    public void nextRound()
    {
        roundNumber++;
        playRound();
    }
    public void playRound()
    {
        switch (roundNumber)
        {
            case 1:
                flamethrower1Animator.SetBool("flameThrowerActive", true);
                break;
            case 2:
                flamethrower3Animator.SetBool("flameThrowerActive", true);
                break;
            case 3:
                flamethrower2Animator.SetBool("flameThrowerActive", true);
                break;
            case 4:
                flamethrower1Animator.SetBool("flameThrowerActive", true);
                flamethrower2Animator.SetBool("flameThrowerActive", true);
                break;
            case 6:
                flamethrower2Animator.SetBool("flameThrowerActive", true);
                flamethrower3Animator.SetBool("flameThrowerActive", true);
                break;
            case 8:
                flamethrower1Animator.SetBool("flameThrowerActive", true);
                flamethrower3Animator.SetBool("flameThrowerActive", true);
                break;
            case 10:
                GameObject.Find("XR Device Simulator").GetComponent<XRDeviceSimulator>().keyboardXTranslateSpeed = 0.5f;
                GameObject.Find("XR Device Simulator").GetComponent<XRDeviceSimulator>().keyboardYTranslateSpeed = 0.5f;
                GameObject.Find("XR Device Simulator").GetComponent<XRDeviceSimulator>().keyboardZTranslateSpeed = 0.5f;
                GameObject.Find("Move").GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
                PlayerPrefs.SetInt("PlayerWon", 2);
                StartCoroutine(WaitAndLoadScene());
                break;
        }
    }
    public void gameLost()
    {
        GameObject.Find("Scream").GetComponent<AudioSource>().Play();

        PlayerPrefs.SetInt("PlayerWon", 1);
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("End Scene");
    }
}
