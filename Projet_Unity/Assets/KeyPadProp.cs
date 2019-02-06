using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadProp : MonoBehaviour
{
    public GameObject KeyPadUI;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<PlayerController>()._frozen = true;
            other.GetComponent<CameraController>().Block(true);
            KeyPadUI.SetActive(true);
        }
    }
}
