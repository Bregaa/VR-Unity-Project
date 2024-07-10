using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVisibility : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Canvas>().enabled = false;
    }

    public void ToggleCanvasVisibility()
    {
        this.GetComponent<Canvas>().enabled = !this.GetComponent<Canvas>().enabled;
    }

}
