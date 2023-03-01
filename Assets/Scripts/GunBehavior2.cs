using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class Gun_Script : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    public float shootTime = 2f;
    public float _timer = 2f;
    public bool canShoot;

    private bool _isShooting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        _isShooting |= (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Return) || Input.GetButton("Fire1"));
        canShoot = _timer <= 0;

    }

    private void FixedUpdate()
    {

        if (_isShooting && canShoot)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position, this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * BulletSpeed;
            canShoot = false;
            _timer = 2f;
        }
        _isShooting = false;
    }
}
