using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log("You won");
                break;
                //aggiungi cambio di scena
        }
    }
    public void gameLost()
    {
        Debug.Log("You lost");
        GameObject.Find("Scream").GetComponent<AudioSource>().Play();
        //wait di 2 secondi
        //aggiungi cambio di scena
    }
}
