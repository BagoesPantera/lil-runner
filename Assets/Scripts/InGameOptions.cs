using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameOptions : MonoBehaviour
{
    public void GameOption(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}
