using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMG_Collider : MonoBehaviour
{

    private int damage = 50;

    //damage to enemy on trigger with the collider of the player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(damage);
            }
        }
    }

}
