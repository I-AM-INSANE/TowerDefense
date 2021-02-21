using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Medium : Abstract_Enemy
{
    #region Methods

    private void Awake()
    {
        enemySpeed = 2f;
        health = 100;
        goldForThisEnemy = 5;
    }

    #endregion
}
