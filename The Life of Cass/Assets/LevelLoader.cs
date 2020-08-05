using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;


    public float transitionTIme = 1f;



    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("StartLoadScreen");

        yield return new WaitForSeconds(transitionTIme);

        SceneManager.LoadScene(levelIndex);

    }

}
