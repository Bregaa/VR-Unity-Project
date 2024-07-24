using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public void EasterEggCollision()
    {
        GameObject.Find("Easter egg - okay that was mean").GetComponent<AudioSource>().Play();
    }
}
