using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller_Follow_Player : MonoBehaviour
{
    //Este Script existe apenas para testar os mapas 
    private Transform target;
    [SerializeField] private float smoothSpeed;

    [SerializeField] private float minX, maxX, minY, maxY;

    private void Start()
    {   //Singletoon
        target = Player_Cotroller.instance.transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }   
}   