using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Abstract_Projectile
{
    #region Fields

    private bool stop = false;
    #endregion

    #region Methods
    private void Awake()
    {
        projectileDamage = 20;
        speed = 10f;
    }

    protected override void Update()
    {
        if (Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

            if (!stop)
            {
                projectileRotation = Target.transform.position - transform.position;
                projectileRotation.Normalize();
                transform.right = projectileRotation;
            }
        }
        else
            Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Collider2D>().enabled = false;
            stop = true;
        }
    }

    #endregion
}
