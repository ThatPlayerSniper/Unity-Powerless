using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Box : MonoBehaviour
{
    public Weapon_Script weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        weapon.addAmmo(weapon.maxAmmoSize);
        Destroy(gameObject);
    }
}
