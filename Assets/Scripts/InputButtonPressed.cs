using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputButtonPressed : MonoBehaviour
{
    public InputAction action;
    public UnityEvent OnPress = new UnityEvent();

    private void Awake()
    {
        action.started += Pressed;
    }

    private void OnDestroy()
    {
        action.started -= Pressed;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        OnPress.Invoke();
    }
}
