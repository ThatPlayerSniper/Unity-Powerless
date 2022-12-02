using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlippingEnemy : MonoBehaviour
{
    public float enemy_prev_pos;
    public float standin_position;
    public float enemy_pos;

    public bool IsFacingLeft = false;
    public bool IsFacingRight = true;
    void Update()
    {
        checkFacing();
    }

    private void checkFacing()
    {
        enemy_pos = transform.position.x;

        if (enemy_prev_pos < enemy_pos)
        {
            enemy_prev_pos = enemy_pos;

            if (IsFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                IsFacingLeft = false;
            }
        }

        if(enemy_prev_pos > enemy_pos) 
        {
            enemy_prev_pos = enemy_pos;

            if (!IsFacingLeft)
            {
                transform.Rotate(0f, 180f, 0f);
                IsFacingLeft = true;
            }
        }
    }
}
