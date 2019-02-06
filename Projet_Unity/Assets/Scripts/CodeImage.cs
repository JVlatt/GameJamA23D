using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeImage : MonoBehaviour
{
    public string code;
    private int[] num = {1,1,1};

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

    public void Unlock()
    {
        string test = num[0].ToString() + num[1].ToString() + num[2].ToString();
        if (test == code)
        {
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._validation);
        }
        else
        {
            SoundControler._soundControler.PlaySound(SoundControler._soundControler._erreur);
        }
    }
}
