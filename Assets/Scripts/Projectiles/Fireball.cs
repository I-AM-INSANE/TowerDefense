using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Abstract_Projectile
{
    #region Methods

    private void Awake()
    {
        projectileDamage = 60;
        speed = 3f;
    }

    #endregion
}
