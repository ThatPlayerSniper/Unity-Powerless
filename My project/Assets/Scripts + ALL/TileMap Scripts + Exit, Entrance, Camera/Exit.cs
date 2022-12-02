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
            //Opção de aviso para a saída de um nível!
            //Debug.LogWarning("O player saiu deste nível!"); 
        }
      
    } 

}
