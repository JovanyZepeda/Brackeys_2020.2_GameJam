using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //Variable Declaration
    private static GameMaster _instance;
    public GameObject activeCP;

    //Set Serialized Fields
    [SerializeField]public Vector3 spawnPosition = new Vector3(0, 0, 0);
    
    //Call this function of Script Reload
    void Awake()
    {
        //If the _instance GameMaster object is not yet set, then run this code block
        if(_instance == null)
        {
            //Set the instance to be this GameMaster Object that the script is in
            _instance = this;

            //Do not destroy this object on a new scene reload
            DontDestroyOnLoad(_instance);
        }
        //Run this is a GameMaster Object has already been set before and exists
        else
        {
            //if a GameMaster Object already exists, then destroy this duplicate gameObject that is associated with this script
            Destroy(gameObject);
        }
    }
}
