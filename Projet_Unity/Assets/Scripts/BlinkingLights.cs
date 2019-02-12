using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLights : MonoBehaviour
{
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(Flashing());

        IEnumerator Flashing ()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                light.enabled = !light.enabled;
            }
        }
    }
}
