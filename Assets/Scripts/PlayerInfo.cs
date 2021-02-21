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

    public int TotalWaves { get; set; }

    #endregion

    #region Methods

    private void Awake()
    {
        PlayerHealth = 5;
        PlayerMoney = 200;
    }
    private void Update()
    {
        if (PlayerHealth == 0)
            Camera.main.GetComponent<StateManager>().EndBattleState(true);
    }

    #endregion
}
