using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Abstract_Projectile
{
    #region Fields

    private bool stop = false;

    #endregion

    #region Methods

    protected override void Update()
    {
        if (!stop)
        {
            projectileRotation = closestEnemy.transform.position - transform.position;
            projectileRotation.Normalize();
            transform.right = projectileRotation;
        }

        if (closestEnemy)
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClosestEnemy"))
            stop = true;
    }

    #endregion
}
