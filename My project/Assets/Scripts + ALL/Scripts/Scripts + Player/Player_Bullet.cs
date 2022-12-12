using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{

    [SerializeField] private float lifeTime; //Life Time of the bullet
    [SerializeField] private float bulletSpeed; //Bullet Speed
    [SerializeField] private LayerMask layerMask; // Layer Mask (Testing)

    public int damage = 50; //Damage the bullet give


    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, lifeTime);              //Destroy bullet after 2s of fly time
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Health>() != null)
        {
            Health health = collider2D.GetComponent<Health>();
            health.Damage(damage);
            Destroy(this.gameObject); 
        }
    }
    
    //Destry's bullet on collision with wall or inanimate GameObject
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
