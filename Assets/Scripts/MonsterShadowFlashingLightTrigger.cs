using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShadowFlashingLightTrigger : MonoBehaviour
{
    public GameObject pilar2;
    public GameObject pilar3;
    public GameObject fallenPilar;

    private GameObject lampOn2;
    private GameObject lampOff2;
    private GameObject lampOn3;
    private GameObject lampOff3;
    private GameObject lampOn4;
    private GameObject lampOff4;
    private float intermittentDuration = 3.4f;
    private float lightOnDuration = 2.5f;
    private float minInterval = 0.1f;
    private float maxInterval = 0.4f;
    private bool scaryNoisePlayed = false;

    public void MonsterShadowFlashingLightTriggered()
    {
        lampOn2 = pilar2.transform.Find("LampRack").Find("LampOn").gameObject;
        lampOff2 = pilar2.transform.Find("LampRack").Find("LampOff").gameObject;
        lampOn3 = pilar3.transform.Find("LampRack").Find("LampOn").gameObject;
        lampOff3 = pilar3.transform.Find("LampRack").Find("LampOff").gameObject;
        lampOn4 = fallenPilar.transform.Find("LampRack").Find("LampOn").gameObject;
        lampOff4 = fallenPilar.transform.Find("LampRack").Find("LampOff").gameObject;

        this.gameObject.SetActive(true);
        fallenPilar.GetComponent<AudioSource>().Play();
        pilar3.GetComponent<AudioSource>().Play();

        StartCoroutine(IntermittentLight());
    }

    private IEnumerator IntermittentLight()
    {
        float endTime = Time.time + intermittentDuration;

        this.transform.Find("Monster noise").GetComponent<AudioSource>().Play();

        while (Time.time < endTime)
        {
            if (!scaryNoisePlayed && Time.time + 0.4f > endTime)
            {
                this.transform.Find("Scary noise").GetComponent<AudioSource>().Play();
                scaryNoisePlayed = true;
            }
            ToggleLamp();
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("6 - Ah").GetComponent<AudioSource>().Play();
        }

        endTime = endTime + lightOnDuration;

        lampOn2.SetActive(true);
        lampOff2.SetActive(false);
        lampOn3.SetActive(true);
        lampOff3.SetActive(false);
        lampOn4.SetActive(true);
        lampOff4.SetActive(false);
        yield return new WaitForSeconds(lightOnDuration);

        this.gameObject.SetActive(false);
        fallenPilar.transform.Find("Sparks intermittent").gameObject.SetActive(true);
        fallenPilar.GetComponent<AudioSource>().Pause();
        pilar3.GetComponent<AudioSource>().Pause();
    }

    private void ToggleLamp()
    {
        bool isLampOn = lampOn4.activeSelf;
        lampOn4.SetActive(!isLampOn);
        lampOff4.SetActive(isLampOn);
        lampOn3.SetActive(!isLampOn);
        lampOff3.SetActive(isLampOn);
        lampOn2.SetActive(!isLampOn);
        lampOff2.SetActive(isLampOn);
    }
}
