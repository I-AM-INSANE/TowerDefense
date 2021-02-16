using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Fields

    private static T instance;

    #endregion

    #region Properties

    public static T Instance
    {
        get 
        {
            //T needObj = FindObjectOfType<T>();

            //if (instance == null)
            //    instance = needObj;
            //else if (instance != needObj)
            //    Destroy(needObj);

            //DontDestroyOnLoad(needObj);

            return instance;
        }
    }
 
    #endregion

    #region Methods



    #endregion
}
