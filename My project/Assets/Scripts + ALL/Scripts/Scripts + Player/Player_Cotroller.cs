using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player_Cotroller : MonoBehaviour
{
    private bool isWalking;


    //Singleton mode
    public static Player_Cotroller instance; //Manter em "SCENE" diferente.

    //Rigidbody 
    private Rigidbody2D rb;

    Animator animator; //Animator 
    
    public Vector2 axisMovement; // X & Y Movement

    //Move speed
    [SerializeField] public float speed;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float sprintSpeed;


    private bool facingRight = true;  //Flip stuff

    public string scenePassword; //guarda um nome quando o player sai da "SCENE".

    //Método do "INSTANCE"
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //Corpo de colisão
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = moveSpeed;
        }

        //mover horizontalmente
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        //mover verticalmente
        axisMovement.y = Input.GetAxisRaw("Vertical");

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if(dir.x > 0 && !facingRight || dir.x < 0 && facingRight)
        {
           CheckForFlipping();
        }

        //if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        //{
        //    animator.SetBool("IsMoving", true); 
        //}
        //else
        //{
        //    animator.SetBool("IsMoving", false);
        //}

        isWalking = axisMovement.x != 0 || axisMovement.y != 0;
        animator.SetBool("IsMoving", isWalking);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = axisMovement.normalized * speed;
    }

    private void CheckForFlipping()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}