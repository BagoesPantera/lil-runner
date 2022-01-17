using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject VolumeButton;
    public GameObject ShareButton;
    public GameObject Quitutton;
    Vector2 VolButtonPos;
    public Vector2 VolumeButtonNewPos;

    private void Start() {
        //
       //VolButtonPos = VolumeButton.transform.position;
        //
        //LeanTween.scale(PlayButton, new Vector3(0,0,0),0.5f).setEaseLinear().setLoopPingPong(1);


        // move sprite towards the target location
        //transform.position = Vector2.MoveTowards(VolButtonPos, VolumeButtonNewPos, 10f * Time.deltaTime);
        
    }
    
   
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void QuitGame(){
        Debug.Log("quit");
        Application.Quit();
    }
}