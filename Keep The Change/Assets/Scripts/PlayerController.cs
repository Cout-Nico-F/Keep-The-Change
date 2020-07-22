using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float startSpeed = 5f;
    [SerializeField] Animator animator;
    Vector2 movement;
    [SerializeField] float startHealth;
    float health;
    [SerializeField] Image healthBar;
    [SerializeField] InventoryUI inventoryUI;

    private void Start()
    {
        health = startHealth;
    }
    void Update()
    {
        MovementVariables();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * startSpeed * movement.x);
        transform.Translate(Vector3.up * Time.deltaTime * startSpeed * movement.y);
    }
    void MovementVariables()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);//little performance trick (sqrmagnitude instead of magnitude)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            healthBar.fillAmount = health / startHealth;
        }
        if (collision.CompareTag("Item"))
        {
            print("item hit..." + collision.GetComponent<ItemUI>().GetItemType());
            ItemUI itemUI = collision.GetComponent<ItemUI>();
            this.inventoryUI.AddItem( new Item( itemUI.GetItemType(), 1));
            Destroy( collision.gameObject );

        }
    }

}
