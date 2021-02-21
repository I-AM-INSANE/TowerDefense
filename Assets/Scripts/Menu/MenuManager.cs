using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager
{
    public static void GoToMenu(Enum_MenuNames name)
    {
        switch (name)
        {
            case Enum_MenuNames.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
}
