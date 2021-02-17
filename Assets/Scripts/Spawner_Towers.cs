using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner_Towers : MonoBehaviour
{
    #region Fields
    private GameObject menuTowerSelection;  // Меню выбора башни
    private Canvas canvasTowerSelection;    // Канвас для меню выбора башни

    [SerializeField]
    private GameObject[] towerKind;     // Все виды башен

    private GameObject objectForSpawn;  // Башня для спавна

    private RaycastHit2D hit;   // Луч для правильного выбора позиции спавна
    private Vector2 mousePosition;  // Позиция мыши
    private GameObject towerSide;   // Подходящее для спавна башни место
    #endregion

    #region Methods
    private void Awake()
    {
        menuTowerSelection = GameObject.FindGameObjectWithTag("Menu_TowerSelection");
        canvasTowerSelection = GameObject.FindGameObjectWithTag("Canvas_TowerSelection").GetComponent<Canvas>();
        canvasTowerSelection.enabled = false;

    }
    public void SelectObjectForSpawn(Enum_Towers tower) // Эта функция сработает при выборе башни
    {
        switch (tower)
        {
            case Enum_Towers.Tower0:
                objectForSpawn = towerKind[0];
                break;

            case Enum_Towers.Tower1:
                objectForSpawn = towerKind[1];
                break;

            case Enum_Towers.Tower2:
                objectForSpawn = towerKind[2];
                break;
        }
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
        canvasTowerSelection.enabled = false;
    }

    #endregion

}
