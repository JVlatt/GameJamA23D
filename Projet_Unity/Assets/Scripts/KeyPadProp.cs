using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadProp : MonoBehaviour
{
    public GameObject KeyPadUI;
    public GameObject _door;
    public float stop;
    public InputField TextField;
    public string Password = "0000";

    private bool unlocked = false;

    private Animator anim;

    private void Start()
    {
        anim = KeyPadUI.GetComponent<Animator>();
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
        if (unlocked && _door.transform.position.y > -stop)
            _door.transform.Translate(new Vector3(0, -Time.deltaTime, 0));
        if (Input.GetKeyDown(KeyCode.Escape) && KeyPadUI.activeInHierarchy )
        {
            Reset();
            GameController._gameController.Freeze(false);
            KeyPadUI.SetActive(false);
        }
    }

    public void Set(int digit)
    {
        TextField.text += digit;
    }

    public void Unlock()
    {
        if (TextField.text == Password)
        {
            unlocked = true;
            KeyPadUI.gameObject.SetActive(false);
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._validation);
            GameController._gameController.Freeze(false);

        }
        else
        {
            TextField.text = "";
            Debug.Log("Mot de Passe incorrect");
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._erreur);
            anim.SetTrigger("shake");
        }
    }

    public void Reset()
    {
        TextField.text = "";
    }
}
