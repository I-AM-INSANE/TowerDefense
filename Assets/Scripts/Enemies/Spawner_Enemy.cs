using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemy : MonoBehaviour
{
    #region Firlds


    Timer spawnTimer;

    [SerializeField] private GameObject enemySpawnPoint;
    [SerializeField] private GameObject[] enemyTypes;
    [SerializeField] private int totalEnemies;
    [SerializeField] private int maxEnemiesOnScreen;
    [SerializeField] private int enemiesPerSpawn;

    private int enemyCounter = 0;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
            SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemiesPerSpawn > 0 && enemyCounter < totalEnemies)
            if (EnemiesOnScreen.Count < maxEnemiesOnScreen)
                for (int i = 0; i < enemiesPerSpawn; i++)
                {
                    EnemiesOnScreen.Add(Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], enemySpawnPoint.transform.position, Quaternion.identity));
                    enemyCounter++;
                }
        spawnTimer.Run();
    }

    #endregion
}
