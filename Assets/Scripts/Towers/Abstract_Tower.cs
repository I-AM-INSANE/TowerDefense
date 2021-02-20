using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Abstract_Tower : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject prefabProjectile;    // Префаб снаряда

    protected float attackRadius = 3f; // Радиус атаки объекта
    private GameObject closestEnemy;    // Ближайший враг для атаки
    private float closestEnemyDistance = float.MaxValue;    // Дистанция до ближайшего врага для атаки

    private Timer timerAttackDelay;     // Таймер для задержки между атакой
    protected float attackDelay = 1f;   // Величина задержки между атакой
    #endregion

    #region Properties

    public abstract int TowerPrice { get; }

    #endregion

    #region Methods

    protected virtual void Awake()
    {
        timerAttackDelay = gameObject.AddComponent<Timer>();
        timerAttackDelay.Duration = attackDelay;
        timerAttackDelay.Run();
    }

    private void Update()
    {
        if (Spawner_Enemy.EnemiesOnScreen.Count > 0)
        {
            SearchClosestEnemy();
            if (closestEnemy && timerAttackDelay.Finished)
                Attack();
        }
    }

    private void SearchClosestEnemy()   // Поиск ближайшего врага для атаки
    {
        closestEnemy = null;
        closestEnemyDistance = float.MaxValue;

        foreach (GameObject enemy in Spawner_Enemy.EnemiesOnScreen)
        {
            float tempDistance = Vector3.Distance(enemy.transform.position, transform.position);    // Дистанция до проверяемого врага

            if (tempDistance <= attackRadius && tempDistance < closestEnemyDistance)
            {
                closestEnemyDistance = tempDistance;
                closestEnemy = enemy;
            }
        }
    }

    private void Attack()
    {
        GameObject newProjectile = Instantiate(prefabProjectile, transform.position, Quaternion.identity);
        Abstract_Projectile abstract_Projectile = newProjectile.GetComponent<Abstract_Projectile>();
        abstract_Projectile.Target = closestEnemy;
        timerAttackDelay.Run();
    }

    #endregion
}
