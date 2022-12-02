using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MedKit_Box : MonoBehaviour
{
    [SerializeField] GameObject player;
    Health health;

    void Start()
    {
        health = player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }


}
