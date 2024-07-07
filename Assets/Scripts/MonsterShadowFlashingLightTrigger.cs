using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShadowFlashingLightTrigger : MonoBehaviour
{
    public GameObject fallenPilar;

    private GameObject lampOn;
    private GameObject lampOff;
    private float intermittentDuration = 3.5f;
    private float lightOnDuration = 1.0f;
    private float minInterval = 0.1f;
    private float maxInterval = 0.4f;

    public void MonsterShadowFlashingLightTriggered()
    {
        lampOn = fallenPilar.transform.Find("LampRack").Find("LampOn").gameObject;
        lampOff = fallenPilar.transform.Find("LampRack").Find("LampOff").gameObject;
        this.gameObject.SetActive(true);

        StartCoroutine(IntermittentLight());
    }

    private IEnumerator IntermittentLight()
    {
        float endTime = Time.time + intermittentDuration;

        while (Time.time < endTime)
        {
            ToggleLamp();
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);
        }

        endTime = endTime + lightOnDuration;
        
        lampOn.SetActive(true);
        lampOff.SetActive(false);
        yield return new WaitForSeconds(lightOnDuration);

        this.gameObject.SetActive(false);
        fallenPilar.transform.Find("Sparks intermittent").gameObject.SetActive(true);
    }

    private void ToggleLamp()
    {
        bool isLampOn = lampOn.activeSelf;
        lampOn.SetActive(!isLampOn);
        lampOff.SetActive(isLampOn);
    }
}
