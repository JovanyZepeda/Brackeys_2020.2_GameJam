//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
    public GameObject activeCP;

    [SerializeField]public Vector3 spawnPosition = new Vector3(0, 0, 0);
    
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
