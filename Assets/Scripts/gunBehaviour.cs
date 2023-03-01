using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehaviour : MonoBehaviour
{
    public GameObject bullet;
    private gameManager gameManager;
    private Renderer rend;
    public float BulletSpeed = 100f;
    private float bulletCount = 12;
    private float fireRate = 3.0f;
    private float nextFire = 0.0f;
    void Start(){
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        rend = GetComponent<MeshRenderer>(); //or whatever render it uses
        rend.enabled = false;
        gameManager.Gun1 = true;
    }
    void FixedUpdate(){
        if(gameManager.Gun1){
            rend.enabled = true;
            if(Input.GetMouseButtonDown(0)&&Time.time>nextFire){
                nextFire = Time.time + fireRate;
                GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
                BulletRB.velocity = this.transform.forward * BulletSpeed;
                //Create bullet
                bulletCount--;
                Debug.Log("shot");
            }
            if(Input.GetKeyDown(KeyCode.R)){
                bulletCount = 12;
                Debug.Log("reload");
            }
        }else{
            rend.enabled = false;
        }
    }
}
