using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used to track where player is?
public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
}
