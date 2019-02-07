using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour
{
    public LayerMask _layer;
    public float cooldown;
    public float maxOppacité;
    public Image feedback;
    private float timer;
    private bool detected;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&&!detected)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, _layer))
            {
                if (hit.transform.parent == transform)
                {
                    if (timer > 0) timer -= Time.deltaTime;
                    else
                    {
                        SoundControler._soundControler.PlaySound(SoundControler._soundControler._vision);
                        detected = true;
                        timer = 2;
                    }
                }
            }else if (timer < cooldown) timer = cooldown;
            Color color = feedback.color;
            color.a = Mathf.Lerp(maxOppacité, 0, timer);
            feedback.color = color;
        }
    }
}
