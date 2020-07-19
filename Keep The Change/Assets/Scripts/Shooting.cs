using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float fireRate;
    float nextFire;
    [SerializeField] Transform fireSource;
    [SerializeField] GameObject bullet;
    void Start()
    {
        if (fireSource == null)
        {
            Debug.Log("No Fire Source");
        }
    }

    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        Instantiate(bullet, transform.position, bullet.transform.rotation);
    }
}