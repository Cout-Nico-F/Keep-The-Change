using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 target;
    Vector3 direction;
    float range = 0.5f;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float damage = 34;
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        direction = (target - transform.position).normalized;
        Destroy(gameObject, range);

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(direction * step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //llamar al metodo hit del enemy golpeado 
            collision.gameObject.GetComponent<EnemyController>().Hit(damage);
            
            Destroy(gameObject);
        }
    }
}
