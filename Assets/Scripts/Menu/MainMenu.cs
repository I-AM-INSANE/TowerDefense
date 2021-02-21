using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1;
    }

    public void QuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
