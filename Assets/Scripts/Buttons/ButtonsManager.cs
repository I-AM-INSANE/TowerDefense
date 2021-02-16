using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    #region Fields



    #endregion

    public void LoadScenePrepareForBattle()
    {
        MenuManager.GoToMenu(Enum_Menus.Menu_PrepareForBattle);
    }

    public void LoadSceenBattle()
    {
        MenuManager.GoToMenu(Enum_Menus.Menu_Battle);
    }
}
