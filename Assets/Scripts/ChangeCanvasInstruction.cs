using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvasInstruction : MonoBehaviour
{
    private int currentPanelNumber;

    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        currentPanelNumber = 1;
    }

    public void changeCanvasPanel()
    {
        canvas.transform.Find(currentPanelNumber.ToString()).gameObject.SetActive(false);
        currentPanelNumber += 1;
        canvas.transform.Find(currentPanelNumber.ToString()).gameObject.SetActive(true);
    }
}
