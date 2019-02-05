using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public LayerMask _layer;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, _layer))
            {
                if (hit.transform.parent == transform)
                    Debug.Log("c'est le bon");
                else
                    Debug.Log("c'est pas le bon");
            }
        }
    }
}
