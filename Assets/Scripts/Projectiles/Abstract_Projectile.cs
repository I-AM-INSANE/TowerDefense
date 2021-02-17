using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstract_Projectile : MonoBehaviour
{
    #region Fields

    protected float speed = 5f;

    protected Vector3 projectileRotation;

    #endregion
    public GameObject Target { get; set; }

    #region Methods

    protected void Start()
    {
    }
    protected virtual void Update()
    {
        if (Target)
        {
            projectileRotation = Target.transform.position - transform.position;
            projectileRotation.Normalize();
            transform.right = projectileRotation;

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
        else
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }

    #endregion
}
