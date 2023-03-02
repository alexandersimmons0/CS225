using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private bool pause;
    private bool gun1;
    public bool Gun1{
        get{return gun1;}
        set{gun1 = value;}
    }
    private bool gun2;
    public bool Gun2{
        get{return gun2;}
        set{gun2 = value;}
    }
    void Update(){
        if(Input.GetKeyUp(KeyCode.Escape)){
            if(!pause){
                Time.timeScale = 0;
                pause=true;
            }else{
                Time.timeScale = 1f;
                pause=false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            gun1 = true;
            gun2 = false;
            Debug.Log("gun 1 active");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            gun1 = false;
            gun2 = true;
            Debug.Log("gun 2 active");
        }
    }
}
