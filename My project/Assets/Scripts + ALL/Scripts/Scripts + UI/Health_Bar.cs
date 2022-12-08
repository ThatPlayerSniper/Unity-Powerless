using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{


    [SerializeField] public GameObject player;
    public Slider slider;

    private void Start()
    {
        
    }

    public void SetHp(int Hp)
    {
        slider.value = Hp;
    }