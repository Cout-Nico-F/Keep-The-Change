using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float startSpeed = 5f;
    [SerializeField] Animator animator = null;
    Vector2 movement;
    [SerializeField] float startHealth = 100f;
    public static float health;
    float lastSpeed;
    public float startEnergy = 18000f;
    float energy;
   // public InventoryUI InventoryUI { get { return inventoryUI; } private set { inventoryUI = value; }}
   // [SerializeField] InventoryUI inventoryUI = null;
    private bool ItemInRange = false;
    private bool CanCraft = false;
    private bool CanHarvest = false;
    private Interactable harvestInteractableRef = null;
   // private ItemUI UIreference;

    [SerializeField] Canvas canvas;
    [SerializeField] private GameObject obj_E;
    [SerializeField] private GameObject obj_F;

   /* private void Awake() {
      this.InventoryUI = ReferenceUI.Instance.InventoryUI;
      if (ReferenceUI.Instance.Inventory != null) {
        this.InventoryUI.SetInventory( ReferenceUI.Instance.Inventory );
        this.InventoryUI.RefreshInventoryItems();
      }
    }
   */
    private void Start()
    {
        health = startHealth;
        lastSpeed = startSpeed;
        energy = startEnergy;
        this.canvas = ReferenceUI.Instance.MainCanvas;
        this.obj_E = canvas.transform.Find("PressKey_E").gameObject;
        this.obj_F = canvas.transform.Find("PressKey_F").gameObject;

        //Fix//canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.Find("PressKey_E").gameObject.SetActive(false);
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
        if(CanHarvest && Input.GetKeyDown(KeyCode.F)) 
        {
          this.Harvest();
        }
        MovementVariables();
            EnergyDrain();
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
    /*
    private void HandleInteractableTriggerEnter(Collider2D collision) 
    {
      string flag = collision.GetComponent<Interactable>().Flag;
      if (flag.Equals("CanCraft")) {
        CanCraft = true;
        //canvas.transform.GetChild(3).gameObject.SetActive(true);
        canvas.transform.Find("PressKey_E").gameObject.SetActive(true);
        }
      if (flag.Equals("CanHarvest")) {
        Interactable interactable = collision.GetComponent<Interactable>();
        CanHarvest = true;
        //canvas.transform.GetChild(4).gameObject.SetActive(true);
        canvas.transform.Find("PressKey_F").gameObject.SetActive(true);
            // store reference to the Interactable
            harvestInteractableRef = interactable;
      }
    }
    

    
      @dev this method name is vague
      i.e. this handles only TriggerEnter collision ... not Collider collisions or Exit collisions
    */
    private void HandleItemCollisions(Collider2D collision) {
      if (collision.CompareTag("Item"))
        {
            ItemInRange = true;
          //  UIreference = collision.GetComponent<ItemUI>();
            /*
            @dev dangerous to call by an array index
            i.e. if someone adds a new child to canvas this will break
            @dev this should probably be in some callable private method to show/hide the E
            we have no way of knowing what some canvas transform child at index 3 is 
            */
            //Fix//canvas.transform.GetChild(3).gameObject.SetActive(true);
            canvas.transform.Find("PressKey_E").gameObject.SetActive(true);
                     
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            ItemInRange = false;
            //Fix//canvas.transform.GetChild(3).gameObject.SetActive(false);
            canvas.transform.Find("PressKey_E").gameObject.SetActive(false);
        }
        if ( collision.CompareTag("Interactable") ) 
        {
          Interactable interactable = collision.GetComponent<Interactable>();
          string flag = interactable.Flag;
          if (flag.Equals("CanCraft")) {
            CanCraft = false;
            ReferenceUI.Instance.HideCraftingUI();
            //Fix//canvas.transform.GetChild(3).gameObject.SetActive(false);
            canvas.transform.Find("PressKey_E").gameObject.SetActive(false);
            }
          if (flag.Equals("CanHarvest")) {
            CanHarvest = false;
            // hide letter F
            //Fix//canvas.transform.GetChild(4).gameObject.SetActive(false);
            canvas.transform.Find("PressKey_F").gameObject.SetActive(false);
            }
        }
         
    }

    private void Harvest() {
      print("harvesting...");
      this.animator.Play("harvestTree");
      // create item from interactableReference
     // Item item = new Item(harvestInteractableRef.spawnsItemType, 1);
     // print("  spawning item : " + item.ToString());

      // create new game object
      GameObject itemSpawn = new GameObject("item-sticks");
    //  ItemUI itemUI = itemSpawn.AddComponent<ItemUI>();
     // itemUI.SetItemType( item.GetItemType() );
      SpriteRenderer spriteRenderer = itemSpawn.AddComponent<SpriteRenderer>();
    //  spriteRenderer.sprite = item.GetSprite();
      BoxCollider2D boxCollider2D = itemSpawn.AddComponent<BoxCollider2D>();
      boxCollider2D.isTrigger = true;
      // quick way to do it , Find is expensive
      itemSpawn.transform.position = harvestInteractableRef.Target.Find("ItemSpawnTarget").transform.position;
      itemSpawn.transform.localScale += new Vector3(3, 3, 0);

      itemSpawn.tag = "Item";
      
    }

    private void Pick ()
    {
      //  Item item = new Item(UIreference.GetItemType(), 1);
       // this.inventoryUI.AddItem( item );
       // Destroy(UIreference.gameObject);
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
    }

    public void Damage(float damage)
    {
        health -= damage;
        ReferenceUI.Instance.GetHealthBarFill().fillAmount = health / startHealth;
    }

    void EnergyDrain()
    {
        energy -= 1;
        ReferenceUI.Instance.GetEnergyBarFill().fillAmount = energy / startEnergy;
    }
}
