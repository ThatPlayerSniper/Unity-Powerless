using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    
    [SerializeField] public GameObject player;
    Health hp;
    public Slider slider;

    private void Start()
    {
         hp = player.GetComponent<Health>();
    }

    private void Update()
    {
        SetMaxHealth(hp.MAX_HEALTH);
        SetHp(hp.currentHealth);
    }

    public void SetMaxHealth(int hp)
    { 
        slider.maxValue= hp;
        slider.value = hp;
    }

    public void SetHp(int hp)
    {
        slider.value = hp;
    }
}