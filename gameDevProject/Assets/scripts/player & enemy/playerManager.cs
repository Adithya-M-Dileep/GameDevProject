using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    #region singleton
    public static playerManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
}
