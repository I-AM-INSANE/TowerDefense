using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstract_Projectile : MonoBehaviour
{
    #region Fields

    protected float speed = 5f;
    private float closestEnemyDistance = float.MaxValue;
    protected GameObject closestEnemy;
    private GameObject[] closestEnemies;

    protected Vector3 projectileRotation;

    #endregion
    public GameObject Target 
    {
        set { Target = value; } 
    }
    #region Methods

    protected void Start()
    {
        closestEnemies = GameObject.FindGameObjectsWithTag("ClosestEnemy");
        foreach (GameObject enemy in closestEnemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < closestEnemyDistance)
            {
                closestEnemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
                closestEnemy = enemy;
            }
        }
    }
    protected virtual void Update()
    {
        projectileRotation = closestEnemy.transform.position - transform.position;
        projectileRotation.Normalize();
        transform.right = projectileRotation;

        if (closestEnemy)
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClosestEnemy"))
            Destroy(gameObject);
    }

    #endregion
}
