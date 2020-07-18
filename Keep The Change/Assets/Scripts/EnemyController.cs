using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    //Enemy Stats
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;

    [Header("Enemy Pathing")]
    // Waypoints
    [SerializeField] Vector3 pointA = new Vector3 (9,-3,0);
    [SerializeField] Vector3 pointB = new Vector3 (9,0,0);
    Vector3 waypointDirection;
    [SerializeField] bool patrolling = false;

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
        SetDirectionToWaypoint();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < targettingRange)
        {
            MoveToTarget(movementDirection);
            patrolling = false;
        }
        else
        {
            MoveToWaypoint(waypointDirection);
        }
    }

    void SetDirectionToTarget()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movementDirection = direction;
        }
        else return;
    }

    void SetDirectionToWaypoint()
    {
        Vector3 directionToA = pointA - transform.position;
        Vector3 directionToB = pointB - transform.position;
        Vector3 direction;
        if (Vector3.Distance(pointA,transform.position) < 0.5f)
        {
            patrolling = true;
            Debug.Log("A");
            direction = directionToB;
            direction.Normalize();
            waypointDirection = direction;
        }
        else if (Vector3.Distance(pointB,transform.position) < 0.5f && patrolling == true)
        {
            Debug.Log("B");
            direction = directionToA;
            direction.Normalize();
            waypointDirection = direction;
        }
        else if (!patrolling)
        {
            Debug.Log("C");
            direction = directionToA;
            direction.Normalize();
            waypointDirection = direction;
        }
        
    }
    void MoveToTarget(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void MoveToWaypoint (Vector3 waypointDirection)
    {
        rb.MovePosition((Vector2)transform.position + ((Vector2)waypointDirection * (moveSpeed/3) * Time.deltaTime));
    }
}