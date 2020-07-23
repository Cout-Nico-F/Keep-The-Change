using UnityEngine;

public class CraftingUI : MonoBehaviour {

  [SerializeField] GameObject player;

  private void Awake() {
    print("CraftingUI Awake...");
    print("craftingUi | this.player : " + this.player);
    print("craftingUi | this.player.GetComponent<PlayerController>() : " + this.player.GetComponent<PlayerController>());
    print("craftingUi | this.player.GetComponent<PlayerController>().InventoryUI : " + this.player.GetComponent<PlayerController>().InventoryUI);
    print("craftingUi | this.player.GetComponent<PlayerController>().InventoryUI.GetInventory() : " + this.player.GetComponent<PlayerController>().InventoryUI.GetInventory());
    
    InventoryUI playerInventoryUI = this.player.GetComponent<PlayerController>().InventoryUI;
    Inventory playerInventory = playerInventoryUI.GetInventory();

    playerInventory.PrintItems();
    //this.player.InventoryUI.GetInventory().PrintItems();
  }

}