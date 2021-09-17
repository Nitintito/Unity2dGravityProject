using System;
using UnityEngine;

[Serializable]
public class S_Sounds
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1;
    [Range(.1f, 3f)]
    public float pitch = 1;
    [Range(0f, 1f)]
    public float spatialBlend = 0;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
