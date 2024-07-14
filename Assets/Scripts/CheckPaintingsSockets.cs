using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckPaintingsSockets : MonoBehaviour
{
    public GameObject door;

    private XRSocketInteractor socket1;
    private XRSocketInteractor socket2;
    private XRSocketInteractor socket3;
    private IXRSelectInteractable paintingSocket1;
    private IXRSelectInteractable paintingSocket2;
    private IXRSelectInteractable paintingSocket3;
    private bool doorOpened;

    void Start()
    {
        socket1 = this.transform.Find("Nail 1").GetComponent<XRSocketInteractor>();
        socket2 = this.transform.Find("Nail 2").GetComponent<XRSocketInteractor>();
        socket3 = this.transform.Find("Nail 3").GetComponent<XRSocketInteractor>();
        paintingSocket1 = null;
        paintingSocket2 = null;
        paintingSocket3 = null;
        doorOpened = false;
    }

    
    void Update()
    {
        if (!doorOpened) {
            paintingSocket1 = socket1.GetOldestInteractableSelected();
            paintingSocket2 = socket2.GetOldestInteractableSelected();
            paintingSocket3 = socket3.GetOldestInteractableSelected();

            if (paintingSocket1 != null && paintingSocket2 != null && paintingSocket3 != null)
            {
                if (paintingSocket1.transform.name.Equals("Painting 1") && paintingSocket2.transform.name.Equals("Painting 2") && paintingSocket3.transform.name.Equals("Painting 3"))
                {
                    door.GetComponent<BoxCollider>().enabled = false;
                    door.transform.Find("Door").transform.Find("Knob").GetComponent<XRGrabInteractable>().enabled = true;
                    door.transform.Find("Door").GetComponent<Rigidbody>().freezeRotation = false;
                    door.GetComponent<AudioSource>().Play();
                    doorOpened = true;
                }
            }
        }

    }
}
