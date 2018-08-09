using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip actualAudio;
    public AudioClip audio01;
    public AudioClip audio02;
    public AudioClip audio03;
    public AudioClip audio04;
    public AudioClip audio05;
    [SerializeField]
    private float volAudio;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        actualAudio = audio01;
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(actualAudio, volAudio);
    }
    public void ChangeAudio(AudioClip audio)
    {
        actualAudio = audio;
    }
}
