using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerZone : MonoBehaviour
{
    public LayerMask _layer;
    public float cooldown;
    public float maxOppacité;
    public Image feedback;
    private float timer;
    private bool detected;
    public bool Exit;
    public bool Play;

    private void OnTriggerEnter(Collider other)
    {
        timer = cooldown;
    }

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
                        VoixManager.voixManager.Playvoice();
                        detected = true;
                        timer = 2;
                        if (Exit) Application.Quit();
                        if (Play) SceneManager.LoadScene(1);
                    }
                }
            }else  timer = cooldown;
            Color color = feedback.color;
            color.a = Mathf.Lerp(maxOppacité, 0, timer);
            feedback.color = color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timer = cooldown;
    }
}
