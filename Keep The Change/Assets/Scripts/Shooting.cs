using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float nextFire;
    [SerializeField] int damage = 10;
    [SerializeField] LayerMask toHit;
    [SerializeField] Transform fireSource;
    [SerializeField] float rayCastDist = 0f;
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
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 sourcePos = new Vector2(fireSource.position.x, fireSource.position.y);
        RaycastHit2D hit = Physics2D.Raycast(sourcePos, mousePos - sourcePos, rayCastDist, toHit);
        Debug.DrawLine(sourcePos, (mousePos - sourcePos) * rayCastDist, Color.green);
        if (hit.collider != null)
        {
            Debug.DrawLine(sourcePos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " for " + damage + "damage.");
        }

    }
}