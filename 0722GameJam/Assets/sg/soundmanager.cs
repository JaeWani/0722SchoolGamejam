using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public AudioSource musicsource;

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
       
    }
    
}
