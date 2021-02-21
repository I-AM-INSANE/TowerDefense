using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lite : Abstract_Enemy
{
    #region Methods

    private void Awake()
    {
        enemySpeed = 3f;
        health = 80;
        goldForThisEnemy = 5;
    }

    #endregion
}
