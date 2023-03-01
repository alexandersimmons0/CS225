using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehaviour2 : MonoBehaviour
{
    public GameObject bullet;
    private gameManager gameManager;
    private Renderer rend;
    public float BulletSpeed = 100f;
    private float bulletCount = 30;
    private float fireRate = 0.1f;
    private float nextFire = 0.0f;
    void Start(){
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        rend = GetComponent<MeshRenderer>(); //or whatever render it uses
        rend.enabled = false;
    }
    void Update(){
        if(gameManager.Gun2){
            rend.enabled = true;
            if(Input.GetMouseButton(0)&&Time.time>nextFire&&bulletCount>=0){
                nextFire = Time.time + fireRate;
                GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
                BulletRB.velocity = this.transform.forward * BulletSpeed;
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
