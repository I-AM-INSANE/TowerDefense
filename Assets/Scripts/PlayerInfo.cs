using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    #region Fields



    #endregion

    #region Properties

    public int PlayerHealth { get; set; }

    public int PlayerMoney { get; set; }

    public int Wave { get; set; }

    #endregion

    #region Methods

    private void Awake()
    {
        PlayerHealth = 20;
        PlayerMoney = 200;
        Wave = 1;
    }

    #endregion
}
