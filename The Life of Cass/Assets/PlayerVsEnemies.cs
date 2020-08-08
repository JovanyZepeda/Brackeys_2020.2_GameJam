using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVsEnemies : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Collider HIt");

        if (other.CompareTag("Enemy")) //if the collided object was the tag Enemy then player respawns
        {

           // Debug.Log("Kill Player");
            PlayerRespawn.KillPlayer();
        }

        //Debug.Log("PLayer is killed");

    }



}
