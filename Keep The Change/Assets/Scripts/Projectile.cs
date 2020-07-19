using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 target;
    Vector3 direction;
    [SerializeField] float speed = 5.0f;
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        direction = (target - transform.position).normalized;

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(direction * step);
    }
}
