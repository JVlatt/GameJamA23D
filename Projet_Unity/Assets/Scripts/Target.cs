using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float timer=2;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LampTrigger")
        {
            Debug.Log(1);
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                gameObject.SetActive(false);
                SoundControler._soundControler.PlaySound(SoundControler._soundControler._vision);
                GetComponentInParent<Lamp>().Exit();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        timer = 2;
    }
}
