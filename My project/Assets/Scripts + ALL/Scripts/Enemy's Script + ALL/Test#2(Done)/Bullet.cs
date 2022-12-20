using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float LifeTime = 0.5f;        //Life time of the bullet
    [SerializeField] private LayerMask layerMask;   //Layer Mask (test of collision)

    GameObject Target;                              //Objecto to find ("player")
    Rigidbody2D BulletRB;                           //Rigidbody 

    public float Speed;                      //Speed of the Bullet (Can be changed in unity)

    public int Damage = 10; //DMG of the bullet

    void Start()
    {
        BulletRB = GetComponent<Rigidbody2D>();

        Target = GameObject.FindGameObjectWithTag("Player");                                                            //Find Target
        Vector2 moveDir = (Target.transform.position - transform.position).normalized * Speed;                          //Get position wher the player is
        BulletRB.velocity = new Vector2(moveDir.x, moveDir.y);                                                          //Destroy bullet after 2s of fly time

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

    public bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 c, Vector2 vA, float sB, out Vector2 result)
    {
        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;
        if (MyMath.SolveQuadratic(a:1-r*r, b:2*r*dC*Mathf.Cos(alpha), c:-(dC*dC), out var root1, out var root2)==0)
        {
            result = Vector2.zero;
            return false;
        }
        var dA = Mathf.Max(a: root1, b: root2);
        var t = dA / sB;
        var C = a + vA * t;
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
