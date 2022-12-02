using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string entrancePassword;

    private void Start()
    {
        if(Player_Cotroller.instance.scenePassword == entrancePassword)
        {
            Player_Cotroller.instance.transform.position = transform.position;
            Debug.LogWarning("O player entrou neste n�vel!:"); //Aviso que o player entrou no n�vel seguinte
        }
        else 
        {
            Debug.LogWarning("WRONG PW"); //Aviso caso a passWord no n�vel seguinte esteja errada: Corrigir a password para corrigir o erro.
        }
        
    }
}
