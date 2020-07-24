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
    public static float health; 
    float lastSpeed;
    [SerializeField] Image healthBar;
    //public InventoryUI InventoryUI { get { return inventoryUI; } private set { inventoryUI = value; }}
    //[SerializeField] InventoryUI inventoryUI;
    private bool ItemInRange = false;
    //private ItemUI UIreference;
    


    [SerializeField] Canvas canvas;


    private void Start()
    {
        health = startHealth;
        lastSpeed = startSpeed;

        this.canvas = ReferenceUI.Instance.MainCanvas;
        canvas.transform.GetChild(3).gameObject.SetActive(false);
    }
    void Update()
    {
        if (!GameManager.gameOver)
        { 
        if(ItemInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pick();
        }
        MovementVariables();
        }
    }
    private void FixedUpdate()
    {
        if (!GameManager.gameOver)
        {
            PlayerMovement();
        }
    }
    void PlayerMovement()
    {
        if ((movement.x > 0.05f || movement.x < -0.05) && (movement.y > 0.05f || movement.y < -0.05)) startSpeed /= 1.4f;//halves the speed when moves diagonal
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
            PushEnemy(collision);
            healthBar.fillAmount = health / startHealth;
        }
        this.HandleItemCollisions(collision);
    }

    private void HandleItemCollisions(Collider2D collision) {
      if (collision.CompareTag("Item"))
        {
            ItemInRange = true;
            //UIreference = collision.GetComponent<ItemUI>();
            //Debug.Log("set ui reference to : " + UIreference);
            canvas.transform.GetChild(3).gameObject.SetActive(true);
                     
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            ItemInRange = false;
            canvas.transform.GetChild(3).gameObject.SetActive(false);
        }
         
    }

    private void Pick ()
    {
        //Debug.Log("current items : " + UIreference.GetItemType());
        //Item item = new Item(UIreference.GetItemType(), 1);
        //Debug.Log("item is : " + item);
        //this.inventoryUI.AddItem(new Item(UIreference.GetItemType(), 1));
        //Destroy(UIreference.gameObject);
    }

    public void SavePlayer()
    {
        //GlobalControl.Instance.Health = this.health;
        GlobalControl.Instance.LastSpeed = this.lastSpeed;
        //GlobalControl.Instance.Inventory = this.inventoryUI.GetInventory();
    }

    private void PushEnemy(Collider2D collision)
    {
        Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        enemyRb.AddForce(awayFromPlayer * 2f, ForceMode.Impulse);
        Debug.Log("Pushing enemy: " + collision.gameObject.name);
    }

}
