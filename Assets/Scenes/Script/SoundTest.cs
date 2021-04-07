using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{

    public SoundsList[] sounds;
    void Start()
    {
        foreach (SoundsList s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        //SoundsList s = Array.Find(sounds, sound => sound.name == name);
        foreach (SoundsList s in sounds)
        {
            if (s.name == name)
            {
                Debug.Log("LOL");
                s.source.Play();
            }
        }
    }
}
