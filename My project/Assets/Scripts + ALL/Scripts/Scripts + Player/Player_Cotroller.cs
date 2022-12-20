using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player_Cotroller : MonoBehaviour
{

    //Rigidbody 
    private Rigidbody2D Rb;

    Animator animator; //Animator 
    
    public Vector2 AxisMovementyx; // X & Y Movement

    //Move speed
    [SerializeField] public float Speed;
    [SerializeField] public float MovingSpeed;
    [SerializeField] public float SprintSpeed;
    private bool isWalking;

    private bool FacingRight = true;  //Flip stuff

    //Singleton mode
    public static Player_Cotroller instance; //Manter em "SCENE" diferente.
    public string scenePassword; //guarda um nome quando o player sai da "SCENE".



    private void Start()
    {
        //Body of collision
        Rb = GetComponent<Rigidbody2D>();
        //Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        PlayerMovement();
        
        //Ability 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;
        }
        else
        {
            Speed = MovingSpeed;
        }

        //Get's raw X value and makes it (+1 up / -1 down)
        AxisMovementyx.x = Input.GetAxisRaw("Horizontal");
        //Get's raw Y value and makes it (+1 up / -1 down)
        AxisMovementyx.y = Input.GetAxisRaw("Vertical");

        //Get's Mouse Position From WorldScreen Camera.
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        //Check "Direction" (dir), and the flips.
        if(dir.x > 0 && !FacingRight || dir.x < 0 && FacingRight)
        {
           CheckForFlipping();
        }

        //Checks if player is moving, then if it is moving turn's on the animation.
        isWalking = AxisMovementyx.x != 0 || AxisMovementyx.y != 0;
        animator.SetBool("IsMoving", isWalking);
    }

    //Makes the player move.
    private void PlayerMovement()
    {
        Rb.velocity = AxisMovementyx.normalized * Speed;
    }

    //Flipping Player
    private void CheckForFlipping()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //Method to not destroy player on load (If player changes level).
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

}