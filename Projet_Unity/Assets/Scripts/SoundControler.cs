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

    private AudioSource _source;

    private void Awake()
    {
        if (_soundControler == null)
            _soundControler = this;
        else
            Destroy(this);

        _source = GetComponent<AudioSource>();
        
        _source.clip = _musicIG;
        _source.loop = true;
        _source.Play();
    }

    public void PlaySound(AudioClip sound)
    {
        _source.PlayOneShot(sound);
    }

    public void FootStep()
    {
        _source.clip = _footStep;
        _source.volume = Random.Range(0.8f, 1.0f);
        _source.pitch = Random.Range(0.8f, 1.1f);
        _source.loop = false;
        _source.Play();

    }

}
