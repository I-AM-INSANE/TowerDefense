using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Heavy : Abstract_Enemy
{
    #region Methods

    private void Awake()
    {
        enemySpeed = 1f;
        health = 200;
        goldForThisEnemy = 15;
    }

    #endregion
}
