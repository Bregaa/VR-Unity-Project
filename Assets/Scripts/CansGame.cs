using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CansGame : MonoBehaviour
{
    public GameObject door;
    public GameObject triggerZone;
    public void CansGameWin()
    {
        door.GetComponent<BoxCollider>().enabled = false;

        door.transform.Find("Door").transform.Find("Knob").GetComponent<XRGrabInteractable>().enabled = true;
        door.transform.Find("Door").GetComponent<Rigidbody>().freezeRotation = false;
        door.GetComponent<AudioSource>().Play();
        GameObject.Destroy(triggerZone);
    }
}
