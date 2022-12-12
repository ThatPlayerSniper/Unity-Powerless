using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss_AI : MonoBehaviour
{
    //Variables

    //Waypoint name.
    public Transform[] patrolPoints;

    //Not being used but planned to.
    Transform currentPatrolPoint;

    //Current patrol waypoint Index
    int currentPatrolIndex;
    public Transform player;                                  //Target

    //Speed by Default (Change to adjust)
    public float speed;                                      //Speed Variable


    //Circle Of the Enemy
    public float patrols;                                     // Patrol area
    public float LineOfSite;                                  // Line of sight
    public float InShootingRange;                             //Area where the enemy is gonna start attacking (if gun)
    public float PersonalSpace;                               // In Range of target

    public float fireRate = 0.5f;
    private float nextFireTime;

    //GameObject's
    public GameObject bullet;
    public GameObject bulletParent;

    //Enemy data from Data script
    //private EnemyData data;

    //Other stuff
    private Rigidbody2D rb;
    public Vector2 axisMovement;


    void Start()
    {
        //Testing
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // SetEnemyValues();
        rb = GetComponent<Rigidbody2D>();

        //Waypont stuff
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
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
        else if (distanceFromPlayer <= InShootingRange && nextFireTime < Time.time)
        {
            shoooting();
        }
        if (distanceFromPlayer < PersonalSpace && distanceFromPlayer > InShootingRange)
        {
            Chase();
        }
    }

    //Waypoint Script
    private void patrol()
    {
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
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    //Shooting 
    private void shoooting()
    {
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
        nextFireTime = Time.time + fireRate;
    }

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
