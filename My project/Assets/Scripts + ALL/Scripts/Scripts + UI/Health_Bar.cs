using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{

    public Slider slider;

    public void SetHp(int Hp)
    {
        slider.value = Hp;
    }
}
