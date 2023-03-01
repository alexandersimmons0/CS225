using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehaviour2 : MonoBehaviour
{
    public GameObject bullet;
    private gameManager gameManager;
    private Renderer rend;
    private float bulletCount = 30;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    void Start(){
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        rend = GetComponent<MeshRenderer>(); //or whatever render it uses
        rend.enabled = false;
    }
    void FixedUpdate(){
        if(gameManager.Gun2){
            rend.enabled = true;
            if(Input.GetMouseButton(0)&&Time.time>nextFire){
                nextFire = Time.time + fireRate;
                //Create Bullet
                bulletCount--;
            }
            if(Input.GetKeyDown(KeyCode.R)){
                bulletCount = 30;
            }
        }else{
            rend.enabled = false;
        }
    }
}