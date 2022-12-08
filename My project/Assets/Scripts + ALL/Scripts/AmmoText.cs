using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{

    public Weapon_Script weapon;                    // Get Variables from Reload method
    public TextMeshProUGUI text;                    // Get Text from UI
    
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
        text.text = $"Health: {health.currentHealth} / {health.MAX_HEALTH}  | {weapon.currentClip} / {weapon.maxClipSize} - {weapon.CurrentAmmo} / {weapon.maxAmmoSize} |";
    }
}
