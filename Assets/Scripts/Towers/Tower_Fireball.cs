using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Fireball : Abstract_Tower
{
    #region Properties

    public override int TowerPrice => 100;

    #endregion

    #region Methods
    protected override void Awake()
    {
        attackDelay = 1f;
        base.Awake();
    }

    #endregion
}
