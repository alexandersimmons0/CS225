using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour;
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
        set{gun1 = value;}
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
    }
}