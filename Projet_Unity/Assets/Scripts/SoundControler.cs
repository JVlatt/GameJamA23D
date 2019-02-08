using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour {

    public AudioClip _ambiance;
    public AudioClip _boutonDigicode;
    public AudioClip _boutonCodeImage;
    public AudioClip _boutonCodeImageDeplacement;
    public AudioClip _erreur;
    public AudioClip _validation;
    public AudioClip _pcOn;
    public AudioClip _comRadio;
    public AudioClip _door;
    public AudioClip _vision;
    public AudioClip _lightOn;
    public AudioClip _lightOff;
    public AudioClip _musicIG;
    public AudioClip _musicMenu;
    public AudioClip _footStep;


    public static SoundControler _soundControler;

    private AudioSource[] _sources;

    private void Awake()
    {
        if (_soundControler == null)
            _soundControler = this;
        else
            Destroy(this);

        _sources = GetComponents<AudioSource>();
        
        _sources[0].clip = _musicIG;
        _sources[0].loop = true;
        _sources[0].Play();
    }

    public void PlaySound(AudioClip sound)
    {
        _sources[1].PlayOneShot(sound);
    }

    public void FootStep()
    {
        _sources[1].clip = _footStep;
        _sources[1].volume = Random.Range(0.8f, 1.0f);
        _sources[1].pitch = Random.Range(0.8f, 1.1f);
        _sources[1].loop = false;
        _sources[1].Play();

    }

}
