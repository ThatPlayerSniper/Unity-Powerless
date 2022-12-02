using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_s : MonoBehaviour
{
    public float health = 2;
    private Transform player;
    public float speed = 2.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = player.position - transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position + (delta * moveSpeed);

       
    }

    private void die()
    {
        if (health <= 0)
        {
           /* Character killerCharacter
            killerCharacter.kills++;*/
            Destroy(this.gameObject);
            Debug.Log("i'm dead" /*+ kills++*/);
        }
    }






}