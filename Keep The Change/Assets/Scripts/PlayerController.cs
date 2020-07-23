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
    float health, lastSpeed;
    [SerializeField] Image healthBar;
    public InventoryUI InventoryUI { get { return inventoryUI; } private set { inventoryUI = value; }}
    [SerializeField] InventoryUI inventoryUI;
    private bool ItemInRange = false;
    private ItemUI UIreference;
    private void Start()
    {
        health = startHealth;
        lastSpeed = startSpeed;
    }
    void Update()
    {
        if(ItemInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pick();
        }
        MovementVariables();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        if ((movement.x > 0.05f || movement.x < -0.05) && (movement.y > 0.05f || movement.y < -0.05)) startSpeed /= 1.5f;//halves the speed when moves diagonal (when line 33&34 have more than 0 in his parameters).
        //GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1; //changes the sorting layer number while navigating Y
        transform.Translate(Vector3.right * Time.deltaTime * startSpeed * movement.x);
        transform.Translate(Vector3.up * Time.deltaTime * startSpeed * movement.y);
        startSpeed = lastSpeed;

    }
    void MovementVariables()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
        this.handleItemCollisions(collision);
    }

    private void handleItemCollisions(Collider2D collision) {
      if (collision.CompareTag("Item"))
        {
            ItemInRange = true;
            UIreference = collision.GetComponent<ItemUI>();
                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            ItemInRange = false;
        }
         
    }

    private void Pick ()
    {
        this.inventoryUI.AddItem(new Item(UIreference.GetItemType(), 1));
        Destroy(UIreference.gameObject);
    }

}
