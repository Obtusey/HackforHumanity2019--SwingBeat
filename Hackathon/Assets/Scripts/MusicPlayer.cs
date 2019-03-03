using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    public void Start()
    {
        instance = this;
    }

    // Gets the current position of the track between 0 and 1

    public float GetMusicPosition()
    {
        var source = GetComponent<AudioSource>();
        return Mathf.Clamp(source.time / source.clip.length, 0f, 1f);
    }

    public void StartPlay()
    {
        var source = GetComponent<AudioSource>();
        source.Play();
    }

    public void StopPlay()
    {
        var source = GetComponent<AudioSource>();
        source.Stop();
    }

    // Set music position by offset between 0 and 1
    public void SetMusicPositionByOffset(float offset)
    {
        var source = GetComponent<AudioSource>();
        source.time = (source.clip.length - 0.1f) * offset;
    }

    // Check if music is playing
    public bool IsPlaying()
    {
        var source = GetComponent<AudioSource>();
        if (source && source.isPlaying)
        {
            return true;
        }
        return false;
    }
}
