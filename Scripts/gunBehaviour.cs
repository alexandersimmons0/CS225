using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehaviour : MonoBehaviour;
{
    public gameObject bullet;
    private gameManager gameManager;
    private Renderer rend;
    private float bulletCount = 12;
    private float fireRate = 3.0f;
    private float nextFire = 0.0f;
    void Start(){
        gameManager = GetObject.Find("gameManager").GetComponent<gameManager>();
        rend = GetComponent<MeshRenderer>(); //or whatever render it uses
        rend.enabled = false;
    }
    void FixedUpdate(){
        if(gameManager.Gun1){
            rend.enabled = true;
            if(Input.GetMouseButtonDown(0)&&Time.time>nextFire){
                nextFire = Time.time + fireRate;
                //Create bullet
                bulletCount--;
            }
            if(Input.GetKeyDown(KeyCode.R)){
                bulletCount = 12;
            }
        }else{
            rend.enabled = false;
        }
    }
}