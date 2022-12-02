using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Script : MonoBehaviour
{
    [SerializeField] private Transform Barrel;  // Cano da arma onde vai sair a bala
    [SerializeField] private float fireRate;  // Cadencia de saida da bala
    [SerializeField] private GameObject bullet; // Gameobject da bala
    public int currentClip, maxClipSize = 10, CurrentAmmo, maxAmmoSize = 100;

    //Controlo do intervalo de tempo entre tiros
    private float fireTimer;

    void Update()
    {
        HandleShooting();                                // Call handleshooting 
    }
    private void HandleShooting()
    {
        if (Input.GetMouseButton(0) && CanShoot())       //Shoot M1 (Mouse Button 1)
        {
            Shoot();  //Shoot
        }
        if (Input.GetKey(KeyCode.R)) 
        {
            reload();
        }
    }

    //Shoot
    private void Shoot()
    {
        if (currentClip > 0)
        {
        fireTimer = Time.time + fireRate;
        Instantiate(bullet, Barrel.position, Barrel.rotation); // Intance of prefab's
        currentClip--;
        }
    }

    private bool CanShoot()
    {
        return Time.time > fireTimer;                  // Timer between bullets
    }

    public void reload() 
    {
        int reloadAmount = maxClipSize - currentClip;  //How many bullets to refill the clip
        reloadAmount = (CurrentAmmo - reloadAmount) >= 0 ? reloadAmount : CurrentAmmo;
        currentClip += reloadAmount;
        CurrentAmmo -= reloadAmount;
    }

    public void addAmmo(int ammoAmount)
    {
        CurrentAmmo += ammoAmount;
        if(CurrentAmmo > maxAmmoSize)
        {
            CurrentAmmo = maxAmmoSize;
        }
    }
}
