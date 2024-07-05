using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseBoxOpened : MonoBehaviour
{
    public GameObject fuseBoxDoor;
    public GameObject containsGrabInteractable;

    private XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = containsGrabInteractable.GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fuseBoxRotation = fuseBoxDoor.transform.localRotation.eulerAngles;
        if (fuseBoxRotation.x > 300 || fuseBoxRotation.x < 270)
        {
            interactable.enabled = true;
        }
        else
        {
            interactable.enabled = false;
        }
    }
}
