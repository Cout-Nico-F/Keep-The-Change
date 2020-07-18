using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    //Enemy Stats
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;

    //[Header("Enemy Pathing")]
    // Waypoints
    //[SerializeField] Vector3 pointA = new Vector3 (0,0,0);
    //[SerializeField] Vector3 pointB = new Vector3 (0,0,0);
    //Vector3 waypoint;

    [Header("Enemy Targetting")]
    [SerializeField] Transform player;
    [SerializeField] float targettingRange = 10f;
    Vector2 movementDirection;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDirectionToTarget();

    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.position,transform.position) < targettingRange)
        { 
        MoveToTarget(movementDirection);
        }
    }

    void SetDirectionToTarget()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movementDirection = direction;
    }
    void MoveToTarget(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}