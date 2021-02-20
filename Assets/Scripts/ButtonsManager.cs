using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    #region Fields

    private Spawner_Towers spawnerTowers;

    #endregion

    #region Methods
    private void Awake()
    {
        spawnerTowers = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Spawner_Towers>();
    }
    public void SpawnTower_Fireball()
    {
        spawnerTowers.SelectObjectForSpawn(Enum_Towers.Tower_Fireball);
    }
    public void SpawnTower_Arrow()
    {
        spawnerTowers.SelectObjectForSpawn(Enum_Towers.Tower_Arrow);
    }
    public void SpawnTower_Rock()
    {
        spawnerTowers.SelectObjectForSpawn(Enum_Towers.Tower_Rock);
    }
    public void RestartOrNext()
    {
        //if ()
    }

    #endregion
}
