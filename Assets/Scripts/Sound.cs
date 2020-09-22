using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioSource source;
    public string name;
    public AudioClip audioClip;
    [Range(0,1)]
    public float volume;
}


