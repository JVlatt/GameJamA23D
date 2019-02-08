using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFinale : MonoBehaviour
{
    public GameObject Walls;
    private bool unlocked = false;
    public float stop = 6;
    public AudioClip omgfin;

    private void Update()
    {
        if (unlocked && Walls.transform.position.y < -stop)
            Walls.transform.Translate(0, -Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            unlocked = true;

        SoundControler._soundControler.PlaySound(omgfin);
    }
}
