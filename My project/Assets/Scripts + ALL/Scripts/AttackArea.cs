using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    //Works well for a bullet
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.GetComponent<Health>()!= null)
        {
            Health health = collider2D.GetComponent<Health>();
            health.Damage(damage);
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
