using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    /// <summary>
    /// Script teste para aplicar noutros
    /// </summary>



    //RigidBody
    private Rigidbody2D rb;

    //Target
    private Transform player;
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    private float speed = 0.75f;

    //Distancia do alvo
    public float lineOfSite;
    public float Inrange;
    private EnemyData data;
    private RaycastHit2D raycast;
    public Vector2 axisMovement;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetEnemyValues();
        rb = GetComponent<Rigidbody2D>();
        raycast = Physics2D.Raycast(this.transform.position, Vector2.down);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (raycast.collider == null /*&& raycast.distance > 3*/)  
        {
            Guard();
        }
        CheckForFlipping();


    }

    private void SetEnemyValues()
    {

       /* GetComponent<Health>().SetHealth(data.hp, data.damage);
        damage = data.damage;
        speed = data.speed;*/
    }

    private void Guard()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > Inrange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, Inrange);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        Debug.Log("Trigger!");
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<Health>() != null) 
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(10);
            }
        }   
    }

   private void CheckForFlipping()
    {
        if (player.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
