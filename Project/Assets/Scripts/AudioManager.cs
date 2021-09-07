using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    Sound s = null;

    void Awake()
    {
        foreach (Sound s in sounds) // sets source sounds variables
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        s = Array.Find(sounds, sound => sound.name == name); // gets specific sound from array

        s.source.Play(); // plays sound
    }

    public void Stop()
    {
        s.source.Stop(); // stops sound
    }
}
