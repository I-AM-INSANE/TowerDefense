using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    #region Fields

    [SerializeField] 
    private Spawner_Towers spawnerTowers;

    #endregion

    #region Methods

    public void SpawnTower0()
    {
        spawnerTowers.SelectObjectForSpawn(Enum_Towers.Tower0);
    }
    public void SpawnTower1()
    {
        spawnerTowers.SelectObjectForSpawn(Enum_Towers.Tower1);
    }
    public void SpawnTower2()
    {
        spawnerTowers.SelectObjectForSpawn(Enum_Towers.Tower2);
    }

    #endregion
}
