using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnsound : MonoBehaviour
{
    public AudioSource clickSound;

    public void ClickSound()
    {
        Debug.Log("play sound");
        clickSound.Play();  
    }
}
