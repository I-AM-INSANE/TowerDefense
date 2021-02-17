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
            return instance;
        }
    }
 
    #endregion

    #region Methods



    #endregion
}
