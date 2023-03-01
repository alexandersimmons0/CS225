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

    private bool _isFiring = false;
    private bool _isReloading = false;
    void Start(){
        gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        rend = GetComponent<MeshRenderer>(); //or whatever render it uses
        rend.enabled = false;
        gameManager.Gun1 = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isFiring = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _isReloading = true;
        }
    }
    void FixedUpdate(){
        if(gameManager.Gun1){
            rend.enabled = true;
            if(_isFiring&&Time.time>nextFire){
                nextFire = Time.time + fireRate;
                GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
                BulletRB.velocity = this.transform.forward * BulletSpeed;
                //Create bullet
                bulletCount--;
                Debug.Log("shot");
            }
            if(_isReloading){
                bulletCount = 12;
                Debug.Log("reload");
                _isReloading = false;
            }
        }else{
            rend.enabled = false;
        }
        _isFiring = false;
    }
}
