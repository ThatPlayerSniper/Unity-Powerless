using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MedKit_Box : MonoBehaviour
{
    [SerializeField] GameObject player;
    Health health;
    public int heal = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            health = player.GetComponent<Health>();
            health.Heal(heal);
        }
        Destroy(gameObject);
    }
}
