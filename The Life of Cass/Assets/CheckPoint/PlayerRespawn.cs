using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    //Declare a private variable of type GameMaster 
    private GameMaster gm;

    //Serialized Fields for the X and Y offset of the respawn
    [SerializeField] float offsetX = -2.5f;
    [SerializeField] float offsetY = 1.0f;

    //Function called upload loading object that the script is attatched to
    void Start()
    {
        //Store the X and Y offset values into a vector
        Vector3 offset = new Vector3(offsetX, offsetY, 0);
        //Get the game master object
        //The Game Master Object contains info for where to respawn the player to
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //move the player to the appropriate spawn point stored in the gamemaster object
        transform.position = gm.spawnPosition + offset;
    }

    //Run this function on every frame
    void Update()
    {
        //If the 'R' key is pressed
        if(Input.GetKeyDown(KeyCode.R))
        {
            //Reload the current scene you are in
            //Reloading the current scene will destroy all objects and recreate them
            //Objects that are used in the DontDestroyOnLoad() function are not deleted
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
