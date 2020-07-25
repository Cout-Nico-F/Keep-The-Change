using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Animator animator = null;

    [Header("Enemy Stats")]
    //Enemy Stats
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    float health;
    [SerializeField] float startHealth = 0f;
    [SerializeField] Image healthBar = null;
    [SerializeField] GameObject enemyCanvas = null;

    [Header("Enemy Pathing")]
    // Waypoints
    [SerializeField] Vector3 pointA = new Vector3(9, -3, 0);
    [SerializeField] Vector3 pointB = new Vector3(9, 0, 0);
    Vector2 waypointDirection;
    [SerializeField] bool patrolling = false;
    bool returning = false;

    [Header("Enemy Targetting")]
    [SerializeField] Transform player = null;
    [SerializeField] float targettingRange = 10f;
    Vector2 movementDirection;
    private bool shouldFollow = true;
    private float attackDistance = 2f;

    void Start()
    {
        health = startHealth;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDirectionToTarget();
        SetDirectionToWaypoint();

        if (!shouldFollow && Vector2.Distance(player.position, transform.position) > targettingRange) {
          shouldFollow = true;
        }

        if (patrolling || returning)
        {
            animator.SetFloat("Vertical", waypointDirection.y);
        }
        else animator.SetFloat("Vertical", movementDirection.y);

    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(player.position, transform.position) < targettingRange)//if its in range to attack:
        {
            MoveToTarget(movementDirection);
            patrolling = false;
            returning = false;
        }
        else
        {
            MoveToWaypoint(waypointDirection);
            returning = true;
        }
    }

    void SetDirectionToTarget()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            movementDirection = direction;

        }
        else return;
    }

    void SetDirectionToWaypoint()
    {
        Vector2 directionToA = pointA - transform.position;
        Vector2 directionToB = pointB - transform.position;
        Vector2 direction;

        if (Vector2.Distance(pointA, transform.position) < 0.1f)
        {
            patrolling = true;
            direction = directionToB;
            direction.Normalize();
            waypointDirection = direction;
        }
        else if (Vector2.Distance(pointB, transform.position) < 0.1f && patrolling == true)
        {
            direction = directionToA;
            direction.Normalize();
            waypointDirection = direction;
        }
        else if (!patrolling)
        {
            direction = directionToA;
            direction.Normalize();
            waypointDirection = direction;
        }

    }
    void MoveToTarget(Vector2 direction)
    {
        float distanceFromPlayer = Vector2.Distance(player.position , transform.position);
        if( distanceFromPlayer > 0.1f && shouldFollow) {
          rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
        if(distanceFromPlayer <= attackDistance && shouldFollow ) {
          // attack animation / etc.
          shouldFollow = false;
        }
    }
    void MoveToWaypoint(Vector2 waypointDirection)
    {
        rb.MovePosition((Vector2)transform.position + (waypointDirection * (moveSpeed / 2) * Time.deltaTime));
    }

    public void Hit( float daño )
    {
        health -= daño;
        enemyCanvas.SetActive(true);
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
            return;
        }
        animator.SetTrigger("hit");
        moveSpeed -= 1;
    }

    private void Die ()
    {
        animator.Play("die");
        moveSpeed = 0;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject, 1.33f);
    }
}