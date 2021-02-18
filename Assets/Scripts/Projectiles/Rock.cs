using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Abstract_Projectile
{
    #region Methods

    private void Awake()
    {
        projectileDamage = 40;
        speed = 2f;
    }

    #endregion
}
