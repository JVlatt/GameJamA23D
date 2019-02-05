using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadManager : MonoBehaviour
{
    public InputField TextField;
    public string Password = "0000";



    public void Set(int digit)
    {
        TextField.text += digit;
    }

    public void Unlock()
    {
        if (TextField.text == Password)
        {
            Debug.Log("Porte déverouillée");
            gameObject.SetActive(false);
        }
        else
        {
            TextField.text = "";
            Debug.Log("Mot de Passe incorrect");
        }
    }

    public void Reset()
    {
        TextField.text = "";
    }


}
