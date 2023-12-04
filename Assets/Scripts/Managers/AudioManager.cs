using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Create Array for sounds
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            //get the Audiosource from the AudioManager GameObject
            //add things to inspector
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //play Theme on start
        Play("Theme");
    }

    public void Play (string name)
    {
        //find the name of the sound if nothing comes back return null.
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;  
        }
        //play sound
        s.source.Play();
    }
    public void Stop(string name)
    {
        //find the name of the sound if nothing comes back return null.
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        //play sound
        s.source.Stop();
    }
}
//FindObjectOfType<AudioManager>().Play("Jump");
