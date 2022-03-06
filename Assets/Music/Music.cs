using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClip;


    public void M(int number)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[number];
        audioSource.Play();
    }
}
