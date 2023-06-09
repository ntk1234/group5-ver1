using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;
    void Start()
    {
  
    }
    void Update()
    {
        if (Input.GetKey("l") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireBullet();
            
        }
    }

    void FireBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}

