using JetBrains.Annotations;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool IsGamePaused;
    public static bool IsSoundMute = false;
    public GameObject PauseMenuUI;

    /*
    public static PauseMenu instance;


    


    private void Awake()
    {
        //Here we check if there is alraedy an instance of the PauseMenu object
        //if there is one we will destory it so that there can only be one instance of PauseMenu
        if (instance == null) //if there is no instance of PauseMenu 
        {
            instance = this; //set instance equal to this gameobject
        }
        else // If there already is an object of PauseMenu
        {
            Destroy(gameObject); // we will destory this new one that survived the transition of scenes
            return; //prevent anymore code from being read
        }


        ///This works with the if else statement above
        ///the argument "gameObject" refers to the object that has this scripe attached
        ///Essentially whenever a new scene is loaded in, this method will prevent an object from being destroy durng the transition
        ///thus the gameobject will persist in all scenes
        DontDestroyOnLoad(gameObject);
    }

    */

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            } 

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }



    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); //0 is the index of the main menu

    }

    public void QuitGame()
    {
        Application.Quit(); //This will close the applicatio
        Debug.Log("Quit");

    }


    public void Mute()
    {

        if (!IsSoundMute) 
        { 
            FindObjectOfType<AudioManager>().PauseSound("Theme");
            IsSoundMute = true;
        } else
        {
            FindObjectOfType<AudioManager>().PlaySound("Theme");
            IsSoundMute = false;
        }
        
      
        
    }


}
