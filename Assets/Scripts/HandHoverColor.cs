using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class HandHoverColor : MonoBehaviour
{
    [Tooltip("The colored hand entity")]
    public GameObject coloredHandController;


    public void ShowColoredHand()
    {
        coloredHandController.SetActive(true);
    }
    public void HideColoredHand()
    {
        coloredHandController.SetActive(false);
    }
}
