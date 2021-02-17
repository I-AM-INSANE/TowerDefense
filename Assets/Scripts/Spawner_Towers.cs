using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner_Towers : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private GameObject[] towerKind;     // Все виды башен

    GameObject objectForSpawn;  // Башня для спавна
    Sprite towerSprite;

    Vector2 mousePosition;
    RaycastHit2D hit;   // Луч для правильного выбора позиции спавна
    #endregion

    #region Methods
    private void Awake()
    {

    }
    public void SelectObjectForSpawn(Enum_Towers tower)
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
        towerSprite = objectForSpawn.GetComponent<SpriteRenderer>().sprite;
        Instantiate(towerSprite);
    }

    private void Update()
    {
        //spriteRenderer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //spriteRenderer.transform.position = new Vector2(transform.position.x, transform.position.y);

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider.CompareTag("TowerSide") && objectForSpawn)
            {
                hit.collider.tag = "TowerSideFull";     // Меняем тег сайда, чтобы нельзя было спавнить на этом сайде повторно
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        Instantiate(objectForSpawn, hit.transform.position, Quaternion.identity);
    }

    #endregion

}
