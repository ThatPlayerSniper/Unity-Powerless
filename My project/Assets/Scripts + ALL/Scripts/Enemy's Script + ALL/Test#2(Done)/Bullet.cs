using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;        //Life time of the bullet
    [SerializeField] private LayerMask layerMask;   //Layer Mask (test of collision)

    GameObject target;                              //Objecto to find ("player")
    Rigidbody2D bulletRB;                           //Rigidbody 

    public float speed = 1.5f;                      //Speed of the Bullet (Can be changed in unity)

    public int damage = 10; //DMG of the bullet

    void Start()
    {
        Destroy(gameObject, lifeTime);

        bulletRB = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");                                                            //Find Target
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;                          //Get position wher the player is
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);                                                          //Destroy bullet after 2s of fly time
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Health>() != null)
        {
            Health health = collider2D.GetComponent<Health>();
            health.Damage(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
