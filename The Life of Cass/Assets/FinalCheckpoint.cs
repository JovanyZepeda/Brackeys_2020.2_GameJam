using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCheckpoint : MonoBehaviour
{
    private GameMaster gm;

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int sceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
            switch(sceneNumber)
            {
                case 1:
                {
                    Vector3 spawn1 = new Vector3(-10f, 0f, 0f);
                    gm.spawnPosition = spawn1;
                    break;
                }
                case 2:
                {
                    Vector3 spawn2 = new Vector3(-6.5f, -2f, 0f);
                    gm.spawnPosition = spawn2;
                    break;
                }
                case 3:
                {
                    Vector3 spawn3 = new Vector3(-6.5f, -2f, 0f);
                    gm.spawnPosition = spawn3;
                    break;
                }
                otherwise:
                {
                    break;
                }
            }
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }


}
