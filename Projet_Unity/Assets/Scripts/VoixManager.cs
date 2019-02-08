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
    public AudioClip lab1;
    public AudioClip lab2;

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
            case 7:
                audioSource.PlayOneShot(phrase4);
                break;
            case 8:
                audioSource.PlayOneShot(phrase5);
                break;
            case 9:
                audioSource.PlayOneShot(phrase7);
                break;
            case 10:
                audioSource.PlayOneShot(phrase8);
                break;
            case 13:
                audioSource.PlayOneShot(phrase9);
                break;
            case 14:
                audioSource.PlayOneShot(lab1);
                break;
            case 15:
                audioSource.PlayOneShot(lab2);
                break;
        }
        state++;
    }
}
