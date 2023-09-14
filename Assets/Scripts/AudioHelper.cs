using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioHelper
{
    //, float volume
    public static float svol;

    private static int activeAudioCount = 0; 
    private const int maxActiveAudioCount = 10;
    public static AudioSource PlayClip2D(AudioClip clip)
    {

        if (activeAudioCount >= maxActiveAudioCount)
        {
            return null;
        }

        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        //audioSource.volume volume;
        svol = PlayerPrefs.GetFloat("svolsv");
        audioSource.volume = svol;

        audioSource.Play();

        Object.Destroy(audioObject, clip.length);

        audioSource.gameObject.AddComponent<DestroyAudioSource>();
        activeAudioCount++;

        return audioSource;
    }
    public class DestroyAudioSource : MonoBehaviour
    {
        private void OnDestroy()
        {
            AudioHelper.activeAudioCount--;
        }
    }
}
