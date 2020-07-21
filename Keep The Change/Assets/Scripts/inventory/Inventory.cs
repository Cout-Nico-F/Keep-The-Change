using System.Collections.Generic;
using UnityEngine;

public class Inventory {

  private List<Item> itemList;

  public Inventory() {
    itemList = new List<Item>();

    this.AddItem( new Item { itemType = Item.ItemType.Sword, amount = 1 });
    Debug.Log(this.itemList.Count);
  }

  public void AddItem( Item item ) {
    this.itemList.Add(item);
  }

}