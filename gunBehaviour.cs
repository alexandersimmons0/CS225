using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBehaviour : MonoBehaviour
{
    public GameObject bullet;
    private gameManager gameManager;
    private GameObject gun;
    public float BulletSpeed = 20f;
    private float bulletCount = 2;
    private float fireRate = 3.0f;
    private float nextFire = 0.0f;
    void Start(){
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        gun = GameObject.Find("g");//.GetComponent<MeshRenderer>(); //or whatever render it uses
        gun.SetActive(true); //SetActive is used to hide(show) and show(true) the gun
        gameManager.Gun1 = true;
    }
    void Update(){
        if(gameManager.Gun1){
           gun.SetActive(true);
            if(Input.GetMouseButtonDown(0)&&Time.time>nextFire&&bulletCount>0){
                nextFire = Time.time + fireRate;
                GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
                BulletRB.velocity = this.transform.forward * BulletSpeed;
                bulletCount--;
                Debug.Log("shot");
            }else if(Input.GetMouseButtonDown(0)&&Time.time>nextFire&&bulletCount<=0){
                Debug.Log("empty");
            }
            if(Input.GetKeyDown(KeyCode.R)){
                bulletCount = 2;
                Debug.Log("reload");
            }
        }else{
           gun.SetActive(false);
        }
    }
    void OnGUI(){
        if(gameManager.Gun1){    
            GUI.Box(new Rect(20, 20, 150, 25), ""+bulletCount);
        }
    }
}
