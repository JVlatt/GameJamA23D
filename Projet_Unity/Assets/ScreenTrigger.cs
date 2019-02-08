using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTrigger : MonoBehaviour
{
    public GameObject Image;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && !Image.activeInHierarchy)
            { 
                Image.SetActive(true);
                SoundControler._soundControler.PlaySound(SoundControler._soundControler._pcOn);
            }
        }

    }
}
