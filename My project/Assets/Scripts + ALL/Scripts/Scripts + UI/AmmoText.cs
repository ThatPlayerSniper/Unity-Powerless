using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{

    public Weapon_Script Weapon;                    // Get Variables from Reload method
    public TextMeshProUGUI TextUI;                    // Get Text from UI
    
    Health health;                                  // Get Variable from health script
    [SerializeField] GameObject player;             // Get gameobject


    void Start()
    {
        health = player.GetComponent<Health>();     // Get health script attached to the player
    }

    private void Update()
    {
        UpdateAmmoText();                           // Update text
    }

    public void UpdateAmmoText()                    // Text config
    {
        TextUI.text = $"|{Weapon.currentClip} / {Weapon.maxClipSize} - {Weapon.CurrentAmmo} / {Weapon.maxAmmoSize} |";
    }

}
                   //Add this to check Health if Health bar stops working.
                   //$"Health: {health.currentHealth} / {health.MAX_HEALTH} 