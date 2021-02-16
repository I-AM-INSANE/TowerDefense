using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : Loader<TowerManager>
{
    #region Fields

    Button_Tower towerButtonPressed;

    #endregion

    #region Methods

    public void SelectedTower(Button_Tower towerSelected)
    {
        towerButtonPressed = towerSelected;
        Debug.Log(towerButtonPressed.gameObject);
    }

    #endregion
}
