using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OrderGunHandling : MonoBehaviour
{
    public SpriteRenderer PlayerRenderer, GunRenderer;

    public void Update()
    {
        if(transform.eulerAngles.z < 0 && transform.eulerAngles.z > 180)
        {
            GunRenderer.sortingOrder = PlayerRenderer.sortingOrder = -1;
        }
        else
        {
            GunRenderer.sortingOrder = PlayerRenderer.sortingOrder = +1;
        }
        
    }
        
}
