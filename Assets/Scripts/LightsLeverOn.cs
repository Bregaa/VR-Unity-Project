using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightsLeverOn : MonoBehaviour
{
    private GameObject lever;
    private Rigidbody leverRigidbody;
    private GameObject knob;
    private CapsuleCollider knobCollider;
    private bool areLightsOn;

    private GameObject pilar1;
    private GameObject pilar2;
    private GameObject pilar3;
    private GameObject pilar4;

    // Start is called before the first frame update
    void Start()
    {
        lever = this.gameObject; //Gets the GameObject the script is attached to
        areLightsOn = false;

        pilar1 = GameObject.Find("Pilar1").transform.Find("LampRack")?.gameObject;
        pilar2 = GameObject.Find("Pilar2").transform.Find("LampRack")?.gameObject;
        pilar3 = GameObject.Find("Pilar3").transform.Find("LampRack")?.gameObject;
        pilar4 = GameObject.Find("Pilar4").transform.Find("LampRack")?.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!areLightsOn))
        {
            Vector3 rotation = lever.transform.localRotation.eulerAngles;
            if(rotation.x < 280 && rotation.x > 40)
            {
                leverRigidbody = lever.GetComponent<Rigidbody>();
                leverRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;

                areLightsOn = true;
                pilar1.transform.Find("LampOn")?.gameObject.SetActive(true);
                pilar1.transform.Find("LampOff")?.gameObject.SetActive(false);
                pilar2.transform.Find("LampOn")?.gameObject.SetActive(true);
                pilar2.transform.Find("LampOff")?.gameObject.SetActive(false);
                pilar3.transform.Find("LampOn")?.gameObject.SetActive(true);
                pilar3.transform.Find("LampOff")?.gameObject.SetActive(false);
                pilar4.transform.Find("LampOn")?.gameObject.SetActive(true);
                pilar4.transform.Find("LampOff")?.gameObject.SetActive(false);
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
}
//276
//        
