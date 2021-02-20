using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Rock : Abstract_Tower
{
    #region Properties
    public override int TowerPrice => 70;

    #endregion

    #region Methods

    protected override void Awake()
    {
        attackDelay = 1.5f;
        base.Awake();
    }

    #endregion
}
