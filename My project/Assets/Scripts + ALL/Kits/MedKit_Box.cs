using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MedKit_Box : MonoBehaviour
{
    [SerializeField] GameObject player;    //Get's Gameobject to get the "HEALTH" Component from it
    Health health;                        // HEALTH Script = health variable
    public int heal = 50;                //Amount of of hp that it will give upon healing

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            health = player.GetComponent<Health>(); //Gets component health from player
            health.Heal(heal);  //gets the variable from the health script and the method "Heal" + the "INT" with the-
                               //-amount of hp that it will recover
        }
        Destroy(gameObject); //Destroys game object upon healing 
    }
}
