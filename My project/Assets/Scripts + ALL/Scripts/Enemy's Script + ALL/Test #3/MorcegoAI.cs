using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoAI : MonoBehaviour
{
    //Variables

    //Waypoint name.
    public Transform[] patrolPoints;

    //Current patrol waypoint Index
    int currentPatrolIndex;
    Transform currentPatrolPoint;               
    public Transform player;                   //Target

    //Speed by Default (Change to adjust)
    public float speed = 1f;
    public int damage = 100;

    //Circle Of the Enemy
    public float patrols;                     // Patrol area
    public float LineOfSite;                  // Line of sight
    public float PersonalSpace;               // In Range of target

    //Enemy data from Data script
    private EnemyData data;                   //Needs Testing 

    //Other stuff
    private Rigidbody2D rb;
    public Vector2 axisMovement;
    private RaycastHit2D raycast;

    void Start()
    {
        //Testing
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // SetEnemyValues();
        rb = GetComponent<Rigidbody2D>();

        raycast = Physics2D.Raycast(this.transform.position, Vector2.down);

        //Waypont stuff
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    void Update()
    {
        //Get Distance from player
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer > patrols)
        {
            patrol();
        }
        if (distanceFromPlayer < patrols && distanceFromPlayer > LineOfSite)
        {
            Chase();
        }
        if (distanceFromPlayer < LineOfSite && distanceFromPlayer > PersonalSpace)
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

    //Draw Circles to check radius.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, patrols);
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
        Gizmos.DrawWireSphere(transform.position, PersonalSpace);
    }

}

