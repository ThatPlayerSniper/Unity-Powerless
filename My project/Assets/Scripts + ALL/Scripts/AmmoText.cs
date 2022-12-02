using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{

    public Weapon_Script weapon;
    public TextMeshProUGUI text;
    
    Health health;
    [SerializeField] GameObject player;


    void Start()
    {
        health = player.GetComponent<Health>();
    }

    
    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"Health: {health.currentHealth} / {health.MAX_HEALTH}  | {weapon.currentClip} / {weapon.maxClipSize} - {weapon.CurrentAmmo} / {weapon.maxAmmoSize} |";
    }
}
