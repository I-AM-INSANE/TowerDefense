using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields

    private GameObject finish;

    private GameObject[] moveingPoints;
    private int targetPoint = 0;

    protected float enemySpeed = 2f;

    #endregion
    private void Awake()
    {
        finish = GameObject.FindGameObjectWithTag("Finish");
    }

    // Start is called before the first frame update
    void Start()
    {
        moveingPoints = GameObject.FindGameObjectsWithTag("MoveingPoint");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
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
        }
    }
}
