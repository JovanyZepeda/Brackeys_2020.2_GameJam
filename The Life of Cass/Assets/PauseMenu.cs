using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool IsGamePaused;
    public static bool IsSoundMute = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            } else
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
