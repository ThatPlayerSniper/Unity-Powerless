using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeha : MonoBehaviour
{
    // How many times should I be hit before I die
    public int health = 2;

    void OnCollisionEnter2D(Collision2D theCollision)
    {

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}