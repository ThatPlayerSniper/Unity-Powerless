using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Test4 : MonoBehaviour
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
    public float Patrols;                                     // Patrol area
    public float LineOfSite;                                  // Line of sight
    public float InShootingRange;                             //Area where the enemy is gonna start attacking (if gun)
    public float PersonalSpace;                               // In Range of target

    public float fireRate = 0.5f;
    private float nextFireTime;

    //GameObject's
    //public GameObject bullet;
    //public GameObject bulletParent;

    //Enemy data from Data script
    //private EnemyData data;

    //Other stuff
    private Rigidbody2D rb;
    public Vector2 axisMovement;

    /// <summary>
    /// ////////////////////////////////////////////////
    /// </summary>
    /// 


    //TEST VARIABLES
    public Rigidbody2D projectile;
    public float projectileSpeed;
    public Rigidbody2D target;

    public void Start()
    {

        //Testing
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // SetEnemyValues();
        rb = GetComponent<Rigidbody2D>();

        //Waypont stuff
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];

        //Shooting time

    }


    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer > Patrols)// Se o player nao estiver perto
        {
            Patrol();
        }
        if (distanceFromPlayer < Patrols && distanceFromPlayer > LineOfSite) // Se for encontrado 
        {
            Chase();
        }
        //Apagar se ouver erro
        if (distanceFromPlayer < LineOfSite && distanceFromPlayer > InShootingRange) // se estiver proximo
        {
            Chase();
        }
        else if (distanceFromPlayer <= InShootingRange && nextFireTime < Time.time) // se esta perto para disparar
        {
            Shoooting();
        }
        if (distanceFromPlayer < PersonalSpace && distanceFromPlayer > InShootingRange) // se esta demasido perto
        {
            Chase();
        }
    }

    //Waypoint Script
    private void Patrol()
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



    public void Shoooting()
    {
        var instance = Instantiate(projectile, transform.position, rotation: quaternion.identity);
        if (InterceptionDirection(a: target.transform.position, b: transform.position, vA: target.velocity, projectileSpeed,
            result: out var direction))
            instance.velocity = direction * projectileSpeed;
        else 
        instance.velocity = (target.transform.position - transform.position).normalized * projectileSpeed;
        nextFireTime = Time.time + fireRate;
    }


        //Draw Circles to check radius.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Patrols);
        Gizmos.DrawWireSphere(transform.position, LineOfSite);
        Gizmos.DrawWireSphere(transform.position, InShootingRange);
        Gizmos.DrawWireSphere(transform.position, PersonalSpace);
    }

    public bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    {
        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;
        if (MyMath.SolveQuadratic(a: 1 - r * r, b: 2 * r * dC * Mathf.Cos(alpha), c: -(dC * dC), out var root1, out var root2) == 0)
        {
            result = Vector2.zero;
            return false;
        }
        var dA = Mathf.Max(a: root1, b: root2);
        var t = dA / sB;
        var c = a + vA * t;
        result = (c - b).normalized;
        return true;

    }
}


public class MyMath
{
    public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }

        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }
}

