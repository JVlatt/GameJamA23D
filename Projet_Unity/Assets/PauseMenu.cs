using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        GameController._gameController.Freeze(false);
        gameObject.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        GameController._gameController.Freeze(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        GameController._gameController.Freeze(false);
    }
}
