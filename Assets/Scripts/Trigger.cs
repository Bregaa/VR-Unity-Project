using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string tagFilter;
    public bool disableOnTriggerEnter;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        Debug.Log(other.gameObject.tag);
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        onTriggerEnter.Invoke();
        if(disableOnTriggerEnter) this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
    }
}
