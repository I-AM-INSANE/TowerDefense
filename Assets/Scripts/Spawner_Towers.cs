using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner_Towers : MonoBehaviour
{
    #region Fields
    private GameObject menuTowerSelection;  // Меню выбора башни
    private Canvas canvasTowerSelection;    // Канвас для меню выбора башни

    [SerializeField] private GameObject prefabTower_Fireball;  // Башня с фаерболами
    [SerializeField] private GameObject prefabTower_Arrow;     // Башня лучников
    [SerializeField] private GameObject prefabTower_Rock;      // Башня с камнями

    PlayerInfo playerInfo;  // Информация о параметрах игрока (ХП, монеты...)

    private GameObject objectForSpawn;  // Башня для спавна

    private RaycastHit2D hit;   // Луч для правильного выбора позиции спавна
    private Vector2 mousePosition;  // Позиция мыши
    private GameObject towerSide;   // Подходящее для спавна башни место

    private int towerPrice;
    #endregion

    #region Methods
    private void Awake()
    {
        playerInfo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInfo>();

        menuTowerSelection = GameObject.FindGameObjectWithTag("Menu_TowerSelection");
        canvasTowerSelection = GameObject.FindGameObjectWithTag("Canvas_TowerSelection").GetComponent<Canvas>();
        canvasTowerSelection.enabled = false;
    }
    public void SelectObjectForSpawn(Enum_Towers tower) // Эта функция сработает при выборе башни
    {
        switch (tower)
        {
            case Enum_Towers.Tower_Fireball:
                objectForSpawn = prefabTower_Fireball;
                towerPrice = objectForSpawn.GetComponent<Tower_Fireball>().TowerPrice;
                break;

            case Enum_Towers.Tower_Arrow:
                objectForSpawn = prefabTower_Arrow;
                towerPrice = objectForSpawn.GetComponent<Tower_Arrow>().TowerPrice;
                break;

            case Enum_Towers.Tower_Rock:
                objectForSpawn = prefabTower_Rock;
                towerPrice = objectForSpawn.GetComponent<Tower_Rock>().TowerPrice;
                break;
        }

        if (playerInfo.PlayerMoney >= towerPrice)
            Spawn();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePosition, Vector2.zero);   // Луч из точки 0,0 до mousePosition

            if (hit.collider.CompareTag("TowerSide"))
            {
                towerSide = hit.collider.gameObject;
                ShowMenuTowerSelection();
            }
        }
        if (Input.GetMouseButtonDown(1))
            canvasTowerSelection.enabled = false;
    }

    private void ShowMenuTowerSelection()   // Если клик на место для башни, то показать меню выбора башни
    {
        menuTowerSelection.transform.position = towerSide.transform.position;    // Передвигаем меню выбора башни к месту для спавна
        canvasTowerSelection.enabled = true;    // Включаем меню, делаем видимым
    }

    private void Spawn()
    {
        towerSide.tag = "TowerSideFull";     // Меняем тег сайда, чтобы нельзя было спавнить на этом сайде повторно
        Instantiate(objectForSpawn, towerSide.transform.position, Quaternion.identity);
        playerInfo.PlayerMoney -= towerPrice;
        canvasTowerSelection.enabled = false;
        objectForSpawn = null;
    }

    #endregion

}
