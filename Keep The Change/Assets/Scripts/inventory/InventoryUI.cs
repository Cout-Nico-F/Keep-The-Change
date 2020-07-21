using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

  private Inventory inventory;
  private MonoBehaviour player;
  private RectTransform itemSlotContainer;
  private Object itemSlotTemplateResource;
  private GameObject canvas;
  private int ITEM_COLUMNS = 4;
  [SerializeField] private float INV_OFFSET_X = 0f;
  [SerializeField] private float INV_OFFSET_Y = 200f;

  private void Awake() {
    Debug.Log("InventoryUi | Awake");
    this.canvas = GameObject.FindGameObjectWithTag("Canvas");
    this.itemSlotTemplateResource = Resources.Load("itemSlotTemplate");
    this.InitInventory();
  }

  private void InitInventory() {
    this.inventory = new Inventory();
    this.RefreshInventoryItems();
  }

  private void RefreshInventoryItems() {
    int x = 0;
    int y = 0;
    float itemSlotCellSize = 61f;

    foreach (Item item in this.inventory.GetItems()) {
      
      this.CreateItem(x, y, itemSlotCellSize, item);
      x++;
      if (x > (ITEM_COLUMNS - 1)) {
        x = 0;
        y++;
      }
    }
  }

  private void CreateItem(int x, int y, float itemSlotCellSize, Item item) {
    GameObject itemSlotTemplate = Instantiate( this.itemSlotTemplateResource ) as GameObject;
    Vector2 positionUpdate = new Vector2((x * itemSlotCellSize) + INV_OFFSET_X, (y * itemSlotCellSize) + INV_OFFSET_Y);
    RectTransform itemSlotTemplateRT = itemSlotTemplate.GetComponent<RectTransform>();
    itemSlotTemplateRT.anchoredPosition = positionUpdate;
    itemSlotTemplate.transform.SetParent (canvas.transform);

    Image image = itemSlotTemplateRT.Find("Image").GetComponent<Image>();
    image.sprite = item.GetSprite();
    
  }

  public void AddItem(Item item) {
    this.inventory.AddItem(item);
    this.RefreshInventoryItems();
  }

}