using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMonsterGrowls : MonoBehaviour
{
    public void PlayMonsterDistantGrowls()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
