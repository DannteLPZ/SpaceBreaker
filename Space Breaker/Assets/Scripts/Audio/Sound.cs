using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string Name;
    public AudioClip AudioClip;
    [Range(0.0f, 1.0f)] public float Volume;
    [Range(0.0f, 1.0f)] public float Pitch;
    public bool Loop;

    [HideInInspector]
    public AudioSource AudioSource;
}
