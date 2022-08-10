using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioHelper
{
    //, float volume
    public static float svol;
    public static AudioSource PlayClip2D(AudioClip clip)
    {
        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        audioSource.clip = clip;
        //audioSource.volume volume;
        svol = PlayerPrefs.GetFloat("svolsv");
        audioSource.volume = svol;

        audioSource.Play();

        Object.Destroy(audioObject, clip.length);
        return audioSource;
    }
}
