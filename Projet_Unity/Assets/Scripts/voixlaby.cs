using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voixlaby : MonoBehaviour
{
    public AudioClip omgfin;
    private void OnTriggerEnter(Collider other)
    {
        SoundControler._soundControler.PlaySound(omgfin);
    }
}
