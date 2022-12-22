using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float LifeTime = 0.5f;        //Life time of the bullet

    GameObject Target;                              //Objecto to find ("player")
    Rigidbody2D BulletRB;                           //Rigidbody 

    public float Speed;                      //Speed of the Bullet (Can be changed in unity)

    public int Damage = 10; //DMG of the bullet

    void Start()
    {
        BulletRB = GetComponent<Rigidbody2D>();

       /* Target = GameObject.FindGameObjectWithTag("Player");                                                            //Find Target
        Vector2 moveDir = (Target.transform.position - transform.position).normalized * Speed;                          //Get position wher the player is
        BulletRB.velocity = new Vector2(moveDir.x, moveDir.y);                                                          //Destroy bullet after 2s of fly time
       */
        Destroy(gameObject, LifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Health>() != null)
        {
            Health health = collider2D.GetComponent<Health>();
            health.Damage(Damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}