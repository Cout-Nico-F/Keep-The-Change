﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float fireRate = 0.75f;
    float nextFire;
    [SerializeField] Transform fireSource = null;
    [SerializeField] GameObject bullet = null;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (fireSource == null)
        {
            Debug.Log("No Fire Source");
        }
    }

    void Update()
    {
        if (GameManager.gameOver)
        { return; }
        if (GameManager.isPaused)
        { return; }
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
        audioSource.Play();
        Instantiate(bullet, transform.position, bullet.transform.rotation);
    }
}