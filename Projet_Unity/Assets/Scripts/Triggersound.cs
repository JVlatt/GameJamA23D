using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Triggersound : MonoBehaviour
{
    public AudioClip sound;
    private bool unlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (unlocked == false)
            SoundControler._soundControler.PlaySound(sound);
        unlocked = true;
    }
}
