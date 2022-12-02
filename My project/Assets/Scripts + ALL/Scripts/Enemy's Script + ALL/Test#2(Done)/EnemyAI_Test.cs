using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyAI_Test : MonoBehaviour
{
    //Variables

    //Waypoint name.
    public Transform[] patrolPoints;

    //Not being used but planned to.
    Transform currentPatrolPoint;

    //Current patrol waypoint Index
    int currentPatrolIndex;
    public Transform player; //Target

    //Speed by Default (Change to adjust)
    public float speed = 1f;
   // private int damage = 5;

    //Circle Of the Enemy
    public float patrols; // Patrol area
    public float LineOfSite; // Line of sight
    public float InShootingRange; //Area where the enemy is gonna start attacking (if gun)
    public float PersonalSpace; // In Range of target

    public float fireRate = 1f;
    private float nextFireTime;

    //Flip Sprite
    public float enemy_prev_pos;
    public float enemy_pos;

    public bool isFacingLeft = false;

    //GameObject's
    public GameObject bullet;
    public GameObject bulletParent; 

    //Enemy data from Data script
    private EnemyData data;

    //Other stuff
    private Rigidbody2D rb;
    private RaycastHit2D raycast;
    public Vector2 axisMovement;
    private SpriteRenderer spriteRenderer;

    float horizontalVelocity;
    public bool facingRight = true;
    Vector3 enemyLocation;


    void Start()
    {
        //Testing
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // SetEnemyValues();
        rb = GetComponent<Rigidbody2D>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();

        //Waypont stuff
        raycast = Physics2D.Raycast(this.transform.position, Vector2.down);
       // currentPatrolIndex = 0;
       // currentPatrolPoint = patrolPoints[currentPatrolIndex]; 
    }

    // Update is called once per frame
    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       


        if (distanceFromPlayer > patrols)
        {
            patrol();
        }
        if (distanceFromPlayer < patrols && distanceFromPlayer > LineOfSite)
        {
            Chase();
        }
        //Apagar se ouver erro
        if (distanceFromPlayer < LineOfSite && distanceFromPlayer > InShootingRange)
        {
            Chase();
        }
        else if(distanceFromPlayer <= InShootingRange && nextFireTime <Time.time)
        {
            shoooting();
        }
        if (distanceFromPlayer < InShootingRange && distanceFromPlayer > PersonalSpace)
        {
            Chase();
        }
    }

    //Waypoint Script
    private void patrol()
    {
        //checkFacing();
        {
            Transform wp = patrolPoints[currentPatrolIndex];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    wp.position,
                    speed * Time.deltaTime);
            }
        }
    }

    //Chase target
    private void Chase()
    {
        //checkFacing();
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }

    private void shoooting()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        nextFireTime = Time.time + fireRate;
    }


    //Enemy Values.
    private void SetEnemyValues()
    {

        /*GetComponent<Health>().SetHealth(data.hp, data.damage);
        damage = data.damage;
        speed = data.speed;*/
    }

/*    private void checkFacing()
    {
        enemy_pos = transform.position.x;

        if (enemy_prev_pos < enemy_pos)
        {
            enemy_prev_pos = enemy_pos;

            if (isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = false;
            }
        }
        else
        {
            enemy_prev_pos = enemy_pos;

            if (!isFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingLeft = true;
            }
        }
    }*/

    //damage to enemy on trigger with the collider of the player
    /*
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(50);
            }
            Destroy(gameObject);
        }
    }*/

    //Draw Circles to check radius.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, patrols);
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
        Gizmos.DrawWireSphere(transform.position, InShootingRange);
        Gizmos.DrawWireSphere(transform.position, PersonalSpace);
    }

}
