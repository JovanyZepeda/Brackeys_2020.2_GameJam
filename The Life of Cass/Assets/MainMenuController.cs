using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    //Since this is a public method, other game object can use this method when this script is attached
    //This script is attached to the "Main Menu" object in the main menu scene
    //This means that anythingin that object can use these funcitions
    public void PlayGame() 
    {
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
