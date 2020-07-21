using UnityEngine;

public class InventoryUI : MonoBehaviour {

  private Inventory inventory;
  private MonoBehaviour player;
  private RectTransform itemSlotContainer;
  private Object itemSlotTemplate;
  private GameObject canvas;
  private int ITEM_COLUMNS = 4;
  private float X_OFFSET = 0f;
  private float Y_OFFSET = 200f;

  private void Awake() {
    Debug.Log("InventoryUi | Awake");
    this.canvas = GameObject.FindGameObjectWithTag("Canvas");
    this.itemSlotTemplate = Resources.Load("itemSlotTemplate");
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
      GameObject itemSlot = Instantiate( this.itemSlotTemplate ) as GameObject;
      itemSlot.GetComponent<RectTransform>().anchoredPosition = new Vector2((x * itemSlotCellSize) + X_OFFSET, (y * itemSlotCellSize) + Y_OFFSET);
      itemSlot.transform.SetParent (canvas.transform);
      x++;
      if (x > (ITEM_COLUMNS - 1)) {
        x = 0;
        y++;
      }
    }
  }

}