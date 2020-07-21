using System.Collections.Generic;
using UnityEngine;

public class Inventory {

  private List<Item> itemList;

  public Inventory() {
    Debug.Log("inventory instantiated...");
    itemList = new List<Item>();

    //this.AddDummyItems();
  }

  private void AddDummyItems() {
    this.AddItem( new Item(ItemType.Sword, 1) );
    this.AddItem( new Item(ItemType.HealthPotion, 1) );
    this.AddItem( new Item(ItemType.ManaPotion, 1) );
  }

  public void AddItem( Item item ) {
    this.itemList.Add(item);
  }

  public List<Item> GetItems() {
    return this.itemList;
  }

}