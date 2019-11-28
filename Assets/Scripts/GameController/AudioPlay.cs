using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public static AudioClip clip;
    public static bool isPlaying;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlaying)
        {
     //       source.clip = clip;
            source.PlayOneShot(clip);
            isPlaying = false;
        }
    }
}
