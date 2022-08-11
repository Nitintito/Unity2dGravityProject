using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioManager : MonoBehaviour
{
    public S_Sounds[] sounds;
    public static S_AudioManager currentInstance;
    private void Awake()
    {
        if (currentInstance == null)
            currentInstance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (S_Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    private void Start()
    {
        Play("Music");
    }

    public void Play(string name)
    {
        S_Sounds s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)// change when we dont need debugging
        {
            Debug.LogWarning("Sound:" + name + "not found!!!!");
            return;
        }
        s.source.Play();
    }
}
