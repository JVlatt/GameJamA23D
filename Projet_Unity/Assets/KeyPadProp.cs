using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadProp : MonoBehaviour
{
    public GameObject KeyPadUI;
    public GameObject _door;

    public bool GAMEJAMOMG = false;

    private void Start()
    {
        KeyPadUI.GetComponent<KeyPadManager>().Link(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            GameController._gameController.Freeze(true);
            KeyPadUI.SetActive(true);
        }
    }

    private void Update()
    {
        if (GAMEJAMOMG && _door.transform.position.y > -(_door.transform.localScale.y)/2)
            _door.transform.Translate(new Vector3(0, -Time.deltaTime, 0));


    }
}
