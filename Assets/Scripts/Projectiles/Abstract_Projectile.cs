using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstract_Projectile : MonoBehaviour
{
    #region Fields
    private Timer destroyOverTimeTimer; // Для уничтожения снаряда с течением времени

    protected float speed = 1f;
  
    protected Vector3 projectileRotation;
    protected int projectileDamage; // Урон от снаряда

    #endregion

    #region Properties
    public GameObject Target { get; set; }

    public int ProjectileDamage
    {
        get { return projectileDamage; }
    }

    #endregion

    #region Methods

    protected void Start()
    {
        destroyOverTimeTimer = gameObject.AddComponent<Timer>();
        destroyOverTimeTimer.Duration = 3;
        destroyOverTimeTimer.Run();
    }
    protected virtual void Update()
    {
        if (destroyOverTimeTimer.Finished)
            Destroy(gameObject);

        if (Target)
        {
            projectileRotation = Target.transform.position - transform.position;
            projectileRotation.Normalize();
            transform.right = projectileRotation;

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);

            if (transform.position == Target.transform.position)
                Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }

    #endregion
}
