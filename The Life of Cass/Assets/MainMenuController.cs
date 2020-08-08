using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameMaster gm;//GameMaster data type to get Game master object

    //Private function call on Scene load
    private void Awake()
    {
        //Store the gameMaster as a variable for later use
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //set the new spawn position back to the spawn position of scene1
        Vector3 SP = new Vector3(-10, 0, 0);
        gm.spawnPosition = SP;
    }

    //Since this is a public method, other game object can use this method when this script is attached
    //This script is attached to the "Main Menu" object in the main menu scene
    //This means that anythingin that object can use these funcitions
    public void PlayGame() 
    {

        FindObjectOfType<AudioManager>().PlaySound("MenuClick");
        //Change the spawn point back to the beginning of Scene1 on a new game

        //This essentially changes the active scene to the next one in line according to build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        //In the editor, the game wont actually unity
        Application.Quit();
    }


}
