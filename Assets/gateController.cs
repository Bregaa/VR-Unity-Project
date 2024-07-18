using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour
{
    private Vector3 closedRotation;
    private Vector3 openRotation;

    private float animationDuration = 2.0f;

    private bool isOpening = false;
    private float animationProgress = 0.0f;

    private void Start()
    {
        closedRotation = this.gameObject.transform.localRotation.eulerAngles;
        openRotation = closedRotation;
        openRotation.y += 25;
    }
    private void Update()
    {
        if (isOpening)
        {
            AnimateGate();
        }
    }

    public void OpenGate()
    {
        isOpening = true;
        animationProgress = 0.0f;
    }

    private void AnimateGate()
    {
        if (animationProgress < 1.0f)
        {
            animationProgress += Time.deltaTime / animationDuration;
            this.transform.localRotation = Quaternion.Lerp(
                Quaternion.Euler(closedRotation),
                Quaternion.Euler(openRotation),
                animationProgress
            );
        }
        else
        {
            isOpening = false;
        }
    }
}
