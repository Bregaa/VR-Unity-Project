using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameWonOrLost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("PlayerWon", 0) == 1)
        {
            this.transform.Find("You Won").gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("PlayerWon", 0) == 2)
        {
            this.transform.Find("You Lost").gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
