//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster _instance;
    public GameObject activeCP;
    public Vector3 spawnPosition;
    
    void Awake()
    {
        if(_instance == null)
        {
            Debug.Log("if");
            _instance = this;
            DontDestroyOnLoad(_instance);
            //DontDestroyOnLoad(activeCP);
        }
        else
        {
            Debug.Log("else");
            Destroy(gameObject);
        }
    }
}
