using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    #region Fields

    private Spawner_Towers spawnerTowers;
    private Spawner_Enemy spawnerEnemy;
    private StateManager stateManager;

    #endregion

    #region Methods
    private void Awake()
    {
        spawnerTowers = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Spawner_Towers>();
        spawnerEnemy = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Spawner_Enemy>();
        stateManager = Camera.main.GetComponent<StateManager>();
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
    public void NextWave()
    {
        Time.timeScale = 1;
        spawnerEnemy.GoToNextWave();
    }
    
    public void Resume()
    {
        stateManager.PauseState(false);
    }
    public void RestartGame()
    {
        stateManager.RestartGame();
    }
    public void GoToMainMenu()
    {
        stateManager.MainMenu();
    }

    #endregion
}
