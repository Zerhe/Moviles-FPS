using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip shoot;
    [SerializeField]
    private float volShoot;


    void Awake () {
        audioSource = GetComponent<AudioSource>();
	}
	
	public void PlayShoot()
    {
        audioSource.PlayOneShot(shoot, volShoot);
    }
}
