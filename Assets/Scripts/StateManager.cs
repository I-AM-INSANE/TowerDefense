using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    #region Methods

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseState(true);
        }
    }

    public void PauseState(bool act)
    {
        GameObject.FindGameObjectWithTag("Canvas_Pause").GetComponent<Canvas>().enabled = act;
        if (act)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndBattleState(bool act)
    {
        if (act)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Canvas_EndBattle").GetComponent<Canvas>().enabled = act;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }


    #endregion
}
