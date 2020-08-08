using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;


    public float transitionTIme = 1f;
    public int _buildIndex;



    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    public  void LoadScene()
    {
        StartCoroutine(LoadLevel(_buildIndex));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("StartLoadScreen");

        yield return new WaitForSeconds(transitionTIme);

        SceneManager.LoadScene(levelIndex);

    }

}
