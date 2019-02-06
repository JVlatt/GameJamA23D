using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadManager : MonoBehaviour
{
    public InputField TextField;
    private GameObject _keyPadController;
    public string Password = "0000";
    private Animator anim;

    private bool _unlocked = false;
    private float _speed = 1.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Set(int digit)
    {
        TextField.text += digit;
    }

    public void Unlock()
    {
        if (TextField.text == Password)
        {
            Debug.Log("Porte déverouillée");
            _keyPadController.GetComponent<KeyPadProp>().GAMEJAMOMG = true;
            gameObject.SetActive(false);
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

    public void Link(GameObject kPC)
    {
        _keyPadController = kPC;
    }
}
