using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Tower : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject tower;

    #endregion

    #region Properties

    public GameObject Tower 
    {
        get { return tower; }
    }

    #endregion
}
