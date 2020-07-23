using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour {

  private Inventory inventory;
  private MonoBehaviour player;
  private RectTransform itemSlotContainer;
  private Object itemSlotTemplateResource;
  private GameObject canvas;
  private int ITEM_COLUMNS = 4;
  [SerializeField] private float INV_OFFSET_X = 0f;
  [SerializeField] private float INV_OFFSET_Y = 200f;
  private List<GameObject> itemSlotReferences;

  private void Awake() {
    this.canvas = GameObject.FindGameObjectWithTag("Canvas");
    this.itemSlotTemplateResource = Resources.Load("itemSlotTemplate");
    this.itemSlotReferences = new List<GameObject>();
    this.InitInventory();
  }

  private void InitInventory() {
    this.inventory = new Inventory();
    this.RefreshInventoryItems();
  }

  public void RefreshInventoryItems() {
    int x = 0;
    int y = 0;
    float itemSlotCellSize = 61f;

    this.ClearItemSlotReferences();

    foreach (Item item in this.inventory.GetItems()) {
      this.DisplayItem(x, y, itemSlotCellSize, item);
      x++;
      if (x > (ITEM_COLUMNS - 1)) {
        x = 0;
        y--;
      }
    }
  }

  private void ClearItemSlotReferences() {
    this.itemSlotReferences.ForEach( (GameObject obj) => {
      Destroy(obj);
    });
    this.itemSlotReferences = new List<GameObject>();
  }

  private void DisplayItem(int x, int y, float itemSlotCellSize, Item item) {
    GameObject itemSlotTemplate = Instantiate( this.itemSlotTemplateResource ) as GameObject;
    this.itemSlotReferences.Add( itemSlotTemplate );
    Vector2 positionUpdate = new Vector2((x * itemSlotCellSize) + INV_OFFSET_X, (y * itemSlotCellSize) + INV_OFFSET_Y);
    RectTransform itemSlotTemplateRT = itemSlotTemplate.GetComponent<RectTransform>();
    itemSlotTemplateRT.anchoredPosition = positionUpdate;
    itemSlotTemplate.transform.SetParent (canvas.transform);

    Image image = itemSlotTemplateRT.Find("Image").GetComponent<Image>();
    image.sprite = item.GetSprite();

    itemSlotTemplateRT.Find("Text").GetComponent<Text>().text = item.amount.ToString();
    
  }

  public void AddItem(Item item) {
    this.inventory.AddItem(item);
    this.RefreshInventoryItems();
  }

  public void SubtractItem(Item item) {
    this.inventory.SubtractItem(item);
    this.RefreshInventoryItems();
  }

  public Inventory GetInventory() {
    return this.inventory;
  }

}