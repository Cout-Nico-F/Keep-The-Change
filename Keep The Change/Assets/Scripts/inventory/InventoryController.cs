using UnityEngine;

public class InventoryController : MonoBehaviour {

  private Inventory inventory;
  private MonoBehaviour player;

  public void init( MonoBehaviour player ) {
    this.player = player;
    this.inventory = new Inventory();
  }

}