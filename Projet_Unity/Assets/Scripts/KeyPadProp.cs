using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadProp : MonoBehaviour
{
    private int[] num = { 1, 1, 1 };
    public GameObject KeyPadUI;
    public GameObject _door;
    public float stop;
    public InputField TextField;
    public string Password = "0000";
    private bool soundplayed;
    public bool firstdigit;
    private float timer=0.1f;

    private bool unlocked = false;
    private bool inside;

    private Animator anim;

    private void Start()
    {
        anim = KeyPadUI.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) &&!inside )
        {
            GameController._gameController.Freeze(true);
            KeyPadUI.SetActive(true);
            timer = 0.5f;
            inside = true;
        }
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if (unlocked && _door.transform.position.y > -stop)
            _door.transform.Translate(new Vector3(0, -Time.deltaTime, 0));
        else if (unlocked && !soundplayed)
        {
            VoixManager.voixManager.Playvoice();
            soundplayed = true;
        }
        if (Input.GetKeyDown(KeyCode.E)  && timer <=0 && inside)
        {
            Reset();
            num =new int[] { 1,1,1};
            GameController._gameController.Freeze(false);
            KeyPadUI.SetActive(false);
            inside = false;
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
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._murtombe);
            VoixManager.voixManager.Playvoice();
            GameController._gameController.Freeze(false);
            inside = false;

        }
        else
        {
            TextField.text = "";
            Debug.Log("Mot de Passe incorrect");
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._erreur);
            anim.SetTrigger("shake");
            if (firstdigit) SoundControler._soundControler.PlaySound(SoundControler._soundControler._aide);
            else SoundControler._soundControler.PlaySound(SoundControler._soundControler._aide);
        }
    }

    public void Reset()
    {
        TextField.text = "";
    }

    public void Add(int numero)
    {
        num[numero]++;
        if (num[numero] > 4) num[numero] = 1;
    }

    public void Soustract(int numero)
    {
        num[numero]--;
        if (num[numero] < 1) num[numero] = 4;
    }

    public void Unlock2()
    {
        string test = num[0].ToString() + num[1].ToString() + num[2].ToString();
        if (test == Password)
        {
            unlocked = true;
            KeyPadUI.gameObject.SetActive(false);
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._validation);
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._murtombe);
            GameController._gameController.Freeze(false);
            inside = false;
            //VoixManager.voixManager.Playvoice();
        }
        else
        {
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._erreur);
            anim.SetTrigger("shake");
            Debug.Log(num[0].ToString() + num[1].ToString() + num[2].ToString());
        }
    }
}
