using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    Text waveText;
    [SerializeField]
    Text moneyText;
    [SerializeField]
    Text healthText;

    int wave;   // Текущая волна
    int playerMoney;    // Монеты игрока
    int playerHealth;   // Здоровье игрока
    const string WavePrefix = "Wave: ";

    private PlayerInfo playerInfo;

    #endregion

    #region Methods

    private void Awake()
    {

    }

    private void Update()
    {
        playerInfo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInfo>();
        wave = playerInfo.Wave;
        playerMoney = playerInfo.PlayerMoney;
        playerHealth = playerInfo.PlayerHealth;

        waveText.text = WavePrefix + wave;
        moneyText.text = playerMoney.ToString();
        healthText.text = playerHealth.ToString();
    }

    #endregion


}
