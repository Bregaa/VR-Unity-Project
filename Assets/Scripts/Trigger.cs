using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tagFilter;
    public bool destroyOnTriggerEnter;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;


    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        onTriggerEnter.Invoke();
        if(destroyOnTriggerEnter) Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
    }
}
