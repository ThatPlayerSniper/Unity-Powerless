using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming_Script : MonoBehaviour
{
    //Player Transform (Can't really explain it)
    [SerializeField] private Transform player;

    //For the Gun
    [SerializeField] private float offset;

    void Update()
    {
        //Calling the method
        Aiming();
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

        transform.position = player.position + (offset * playerToMouseDir.normalized);

        Vector3 AimLocalScale = Vector3.one;

        if (angle > 90 || angle < -90)
        {
            AimLocalScale.y = -1f;
        }
        else
        {
            AimLocalScale.y = 1f;
        }

        transform.localScale = AimLocalScale;

    }
}
