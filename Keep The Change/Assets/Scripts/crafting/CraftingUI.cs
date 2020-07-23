using UnityEngine;
using System.Collections.Generic;

public class CraftingUI : MonoBehaviour {

  [SerializeField] GameObject player;
  private InventoryUI playerInventoryUI;

  private void Awake() {
    print("CraftingUI Awake...");
    // print("craftingUi | this.player : " + this.player);
    // print("craftingUi | this.player.GetComponent<PlayerController>() : " + this.player.GetComponent<PlayerController>());
    // print("craftingUi | this.player.GetComponent<PlayerController>().InventoryUI : " + this.player.GetComponent<PlayerController>().InventoryUI);
    // print("craftingUi | this.player.GetComponent<PlayerController>().InventoryUI.GetInventory() : " + this.player.GetComponent<PlayerController>().InventoryUI.GetInventory());
    
    this.playerInventoryUI = this.player.GetComponent<PlayerController>().InventoryUI;

    playerInventoryUI.GetInventory().PrintItems();
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.C)) {
      this.TryCraft();
    }
  }

  private bool hasItems(ItemType itemA, ItemType itemB) {

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

    if (this.hasItems(ItemType.Sword, ItemType.HealthPotion)) {
      print("sword and healthpot found!");
      // remove those items from player inventory
      // add crafted item to player inventory
      this.playerInventoryUI.AddItem(new Item(ItemType.R_FirePotion, 1));
    } else {
      print("player inventory missing items");
    }

    return true;
  }

}