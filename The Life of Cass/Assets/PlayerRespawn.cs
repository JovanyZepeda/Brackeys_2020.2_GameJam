using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] float offsetY = 2.5f;
    [SerializeField] float offsetX = -1.0f;

    void Start()
    {
        Vector3 offset = new Vector3(offsetX, offsetY, 0);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.spawnPosition + offset;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
