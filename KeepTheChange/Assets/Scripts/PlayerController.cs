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
    public InventoryUI InventoryUI { get { return inventoryUI; } private set { inventoryUI = value; }}
    [SerializeField] InventoryUI inventoryUI;
    private bool ItemInRange = false;
    private bool CanCraft = false;
    private ItemUI UIreference;
    


    [SerializeField] Canvas canvas;

    private void Awake() {
      this.InventoryUI = ReferenceUI.Instance.InventoryUI;
      if (ReferenceUI.Instance.Inventory != null) {
        this.InventoryUI.SetInventory( ReferenceUI.Instance.Inventory );
        
        
        this.InventoryUI.RefreshInventoryItems();
      }
    }

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
        if(CanCraft && Input.GetKeyDown(KeyCode.E)) 
        {
          ReferenceUI.Instance.ToggleCraftingUI();
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

    /*
    @dev : 
    there is another trigger somewhere that makes this get called twice.
    leaving this as is for now but this double trigger enter call shouldn't happen.
    @dev :
    this method calls HandleItemCollisions but OnTriggerExit2D calls nothing 
    if you call 'HandleSomething' on some Enter method
    you should be calling 'HandleSomethingWhatever' on some Exit method
    without this just adds confusion
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Enemy") )
        {
            health -= 10;
            healthBar.fillAmount = health / startHealth;
            PushEnemy( collision );
        }
        this.HandleItemCollisions( collision );
        if ( collision.gameObject.CompareTag("Interactable") ) 
        {
          this.HandleInteractableTriggerEnter( collision );
        }
    }

    private void HandleInteractableTriggerEnter(Collider2D collision) 
    {
      string flag = collision.GetComponent<Interactable>().Flag;
      if (flag.Equals("CanCraft")) {
        CanCraft = true;
        canvas.transform.GetChild(3).gameObject.SetActive(true);
      }
    }

    /*
      @dev this method name is vague
      i.e. this handles only TriggerEnter collision ... not Collider collisions or Exit collisions
    */
    private void HandleItemCollisions(Collider2D collision) {
      if (collision.CompareTag("Item"))
        {
            ItemInRange = true;
            UIreference = collision.GetComponent<ItemUI>();
            /*
            @dev dangerous to call by an array index
            i.e. if someone adds a new child to canvas this will break
            @dev this should probably be in some callable private method to show/hide the E
            we have no way of knowing what some canvas transform child at index 3 is 
            */
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
        if ( collision.CompareTag("Interactable") ) 
        {
          string flag = collision.GetComponent<Interactable>().Flag;
          if (flag.Equals("CanCraft")) {
            CanCraft = false;
            ReferenceUI.Instance.HideCraftingUI();
            canvas.transform.GetChild(3).gameObject.SetActive(false);
          }
        }
         
    }

    private void Pick ()
    {
        Item item = new Item(UIreference.GetItemType(), 1);
        this.inventoryUI.AddItem( item );
        Destroy(UIreference.gameObject);
    }

    public void SavePlayer()
    {
        //GlobalControl.Instance.Health = this.health;
        GlobalControl.Instance.LastSpeed = this.lastSpeed;
        //GlobalControl.Instance.Inventory = this.inventoryUI.GetInventory();
    }

    private void PushEnemy(Collider2D collision)
    {
        Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        enemyRb.AddForce(awayFromPlayer * 1.5f, ForceMode2D.Impulse);
        Debug.Log("Pushing enemy: " + collision.gameObject.name);
    }

}
