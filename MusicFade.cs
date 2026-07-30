using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FadeOut(float duration)
    {
        StartCoroutine(Fade(duration));
    }

    IEnumerator Fade(float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}