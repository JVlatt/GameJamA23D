using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoixManager : MonoBehaviour
{
    public static VoixManager voixManager;
    private int state;
    private AudioSource audioSource;

    public AudioClip phrase1;
    public AudioClip phrase2;
    public AudioClip phrase3;
    public AudioClip phrase4;
    public AudioClip phrase5;
    public AudioClip phrase7;
    public AudioClip phrase8;
    public AudioClip phrase9;
    public AudioClip phraseintro;
    public AudioClip phraseoutro;

    private void Awake()
    {
        voixManager = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Playvoice()
    {
        switch (state)
        {
            case 0 : audioSource.PlayOneShot(phraseintro);
                    break;
            case 1: audioSource.PlayOneShot(phrase1);
                break;
            case 3:
                audioSource.PlayOneShot(phrase2);
                break;
            case 4:
                audioSource.PlayOneShot(phrase3);
                break;
            case 5:
                audioSource.PlayOneShot(phrase4);
                break;
        }
    }
}
