using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner_Enemy : MonoBehaviour
{
    #region Firlds
    Timer spawnTimer;

    [SerializeField] private GameObject prefabEnemyLite;
    [SerializeField] private GameObject prefabEnemyMedium;
    [SerializeField] private GameObject prefabEnemyHeavy;

    [SerializeField] private GameObject enemySpawnPoint;    // Точка для спавна
    private List<GameObject> enemiesForSpawn = new List<GameObject>();   // Виды врагов для спавна
    private int totalEnemies;  // Общее количество врагов за волну

    private int enemyCounter;   // Количество врагов, вошедших в игру

    private int numOfWave = 0;    // Номер текущей волны

    #endregion

    #region Properties

    public static List<GameObject> EnemiesOnScreen { get; set; }

    #endregion

    #region Methods
    private void Awake()
    {
        EnemiesOnScreen = new List<GameObject>();
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 1f;
        spawnTimer.Run();
    }

    private void Update()
    {
        if (spawnTimer.Finished)
            SpawnEnemy();

        if (EnemiesOnScreen.Count == 0 && totalEnemies > 0 && enemyCounter == totalEnemies)
            NextWaveButtonOn();
    }
    public void GoToNextWave()
    {
        enemyCounter = 0;
        numOfWave++;
        switch (numOfWave)
        {
            case 1:
                Wave1();
                break;
            case 2:
                Wave2();
                break;
            case 3:
                Wave3();
                break;
        }
        NextWaveButtonOff();
    }

    private void SpawnEnemy()
    {
        if (enemyCounter < totalEnemies)
        {
            EnemiesOnScreen.Add(Instantiate(enemiesForSpawn[Random.Range(0, enemiesForSpawn.Count)], enemySpawnPoint.transform.position, Quaternion.identity));
            enemyCounter++;
        }
        spawnTimer.Run();
    }

    private void NextWaveButtonOn() // Включаю кнопку "Next wave"
    {
        GameObject.FindGameObjectWithTag("HUD").transform.Find("Button_NextWave").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("HUD").transform.Find("Button_NextWave").GetComponent<Image>().enabled = true;
        GameObject.FindGameObjectWithTag("HUD").transform.Find("Button_NextWave").transform.Find("NextWaveText").GetComponent<Text>().enabled = true;
    }
    
    private void NextWaveButtonOff()    // Выключаю кнопку "Next wave"
    {
        GameObject.FindGameObjectWithTag("HUD").transform.Find("Button_NextWave").GetComponent<Button>().enabled = false;
        GameObject.FindGameObjectWithTag("HUD").transform.Find("Button_NextWave").GetComponent<Image>().enabled = false;
        GameObject.FindGameObjectWithTag("HUD").transform.Find("Button_NextWave").transform.Find("NextWaveText").GetComponent<Text>().enabled = false;
    }

    private void Wave1()
    {
        totalEnemies = 10;
        enemiesForSpawn.Add(prefabEnemyMedium);
    }
    private void Wave2()
    {
        totalEnemies = 15;
        enemiesForSpawn.Add(prefabEnemyLite);
    }
    private void Wave3()
    {
        totalEnemies = 20;
        enemiesForSpawn.Add(prefabEnemyHeavy);
    }

    #endregion
}
