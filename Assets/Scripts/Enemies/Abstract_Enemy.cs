using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstract_Enemy : MonoBehaviour
{
    #region Fields

    private GameObject finish;

    private GameObject[] moveingPoints;
    private int targetPoint = 0;

    protected float enemySpeed = 0;
    protected int health = 10;

    private Animator anim;
    Timer destroyEnemyTimer;    // Для уничтожения умерших врагов

    private bool isDead = false;
    #endregion

    #region Methods
    private void Start()
    {
        moveingPoints = Resources.LoadAll<GameObject>("MoveingPoints_Level1");

        anim = GetComponent<Animator>();
        finish = GameObject.FindGameObjectWithTag("Finish");

        destroyEnemyTimer = gameObject.AddComponent<Timer>();
        destroyEnemyTimer.Duration = 5;
    }

    private void Update()
    {
        if (!isDead)
            MoveToPoint();
        if (destroyEnemyTimer.Finished)
            Destroy(gameObject);
    }

    private void MoveToPoint()
    {
        if (targetPoint < moveingPoints.Length)
            transform.position = Vector2.MoveTowards(transform.position, moveingPoints[targetPoint].transform.position, enemySpeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, finish.transform.position, enemySpeed * Time.deltaTime);

        if (targetPoint < moveingPoints.Length && moveingPoints[targetPoint].transform.position == transform.position)
            targetPoint++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Spawner_Enemy.EnemiesOnScreen.Remove(gameObject);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInfo>().PlayerHealth--;
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (health > 0)
            {
                anim.Play("EnemyHurt");
                health -= collision.gameObject.GetComponent<Abstract_Projectile>().ProjectileDamage;
            }
            if (health <= 0)
            {
                isDead = true;
                anim.SetTrigger("isDead");
                destroyEnemyTimer.Run(); 
                GetComponent<Collider2D>().enabled = false; // Если объект умер, отключаем взаимодействие с ним
                Spawner_Enemy.EnemiesOnScreen.Remove(gameObject);   // Чтобы не выбирать объект в качестве closestTarget в Abstract_Tower
            }
        }
    }

    #endregion
}
