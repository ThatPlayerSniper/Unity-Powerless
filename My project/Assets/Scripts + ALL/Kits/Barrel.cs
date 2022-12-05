using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Future Sscore goes here + spawn kits

        Destroy(gameObject);
    }
}
