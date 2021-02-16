using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject enemySpawnManager;

    #endregion

    #region Methods

    private void Awake()
    {
        if (!EnemySpawnManager.instance)
            Instantiate(enemySpawnManager);
    }

    #endregion
}
