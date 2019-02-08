using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBackup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 10, other.transform.position.z);
    }
}
