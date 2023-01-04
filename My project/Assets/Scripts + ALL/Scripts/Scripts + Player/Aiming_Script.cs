using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming_Script : MonoBehaviour
{
    //Player Transform (Can't really explain it)
    [SerializeField] private Transform player;
    public SpriteRenderer PlayerRenderer, GunRenderer;
    //Space for the gun
    [SerializeField] private float offset;

    void Update()
    {
        Aiming();                 //Calling the method
    }

    private void Aiming()
    {
        //Rotation
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(player.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        //Position
        Vector3 playerToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        playerToMouseDir.z = 0;

        //Get mouse position
        transform.position = player.position + (offset * playerToMouseDir.normalized);
        Vector3 AimLocalScale = Vector3.one;

        //Angle rotation Trigger
        if (angle > 90 || angle < -90)
        {
            AimLocalScale.y = -1f;
        }
        else
        {
            AimLocalScale.y = 1f;
        }

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            GunRenderer.sortingOrder = PlayerRenderer.sortingOrder - 1;
        }
        else
        {
            GunRenderer.sortingOrder = PlayerRenderer.sortingOrder + 1;
        }

        transform.localScale = AimLocalScale;


    }
}
