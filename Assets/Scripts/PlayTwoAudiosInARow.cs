using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTwoAudiosInARow : MonoBehaviour
{
    public AudioSource firstAudioSource;
    public AudioSource secondAudioSource;

    public void PlayTwoAudios()
    {
        StartCoroutine(PlayAudioSequence());
    }

    private IEnumerator PlayAudioSequence()
    {
        firstAudioSource.Play();

        float firstClipLength = firstAudioSource.clip.length - 0.2f;
        yield return new WaitForSeconds(firstClipLength);

        secondAudioSource.Play();
    }
}
