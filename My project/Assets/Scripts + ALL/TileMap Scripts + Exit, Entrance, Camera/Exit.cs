using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    public string sceneName;
    [SerializeField] private string newScenePassword;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player_Cotroller.instance.scenePassword = newScenePassword;
            SceneManager.LoadScene(sceneName);
            //Op��o de aviso para a sa�da de um n�vel!
            //Debug.LogWarning("O player saiu deste n�vel!"); 
        }
      
    } 

}
