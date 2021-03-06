using UnityEngine;
using System.Collections.Generic;

public class CraftingUI : MonoBehaviour {

  [SerializeField] GameObject player;
  protected InventoryUI playerInventoryUI;

  private void Awake() {
    this.playerInventoryUI = ReferenceUI.Instance.InventoryUI;
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.C)) {
      this.TryCraft();
    }
  }

  protected bool hasItems(ItemType itemA, ItemType itemB) {

    List<Item> items = this.playerInventoryUI.GetInventory().GetItems();
    bool aFound = false;
    bool bFound = false;
    items.ForEach( (Item item) => {
      if (item.GetItemType() == itemA) {
        aFound = true;
      }
      if (item.GetItemType() == itemB) {
        bFound = true;
      }
    });
    return (aFound && bFound);
  }

  private bool TryCraft() {

    ItemType demoTypeA = ItemType.PinkFruit;
    ItemType demoTypeB = ItemType.RedShroom;

    if (this.hasItems(demoTypeA, demoTypeB)) {
      // remove those items from player inventory
      this.playerInventoryUI.SubtractItem(new Item(demoTypeA, 1));
      this.playerInventoryUI.SubtractItem(new Item(demoTypeB, 1));
      // add crafted item to player inventory
      this.playerInventoryUI.AddItem(new Item(ItemType.HealthPotion, 1));
    } else {
      print("player inventory missing items");
    }

    return true;
  }

}