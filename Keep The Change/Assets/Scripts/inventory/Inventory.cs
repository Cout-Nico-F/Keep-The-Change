using System.Collections.Generic;
using UnityEngine;

public class Inventory {

  private List<Item> itemList;

  public Inventory() {
    Debug.Log("inventory instantiated...");
    this.itemList = new List<Item>();
    //this.AddDummyItems();
  }

  private bool ContainsItem( Item item ) {
    foreach (Item i in this.itemList) {
      if (i.GetItemType() == item.GetItemType()) {
        return true;
      }
    }
    return false;
  }

  private void AddToAmount( ItemType type ) {
    foreach (Item i in this.itemList) {
      if (i.GetItemType().Equals(type)) {
        i.amount++;
      }
    }
  }

  public void AddItem( Item item ) {
    Debug.Log("adding item type : " + item.GetType());
    Debug.Log("  list contains ? " + this.ContainsItem(item));
    if (this.ContainsItem(item)) {
      this.AddToAmount(item.GetItemType());
      Debug.Log("adding to stack of : " + item.GetItemType());
    } else {
      this.itemList.Add(item);
    }
  }

  public List<Item> GetItems() {
    return this.itemList;
  }

  private void AddDummyItems() {
    this.AddItem( new Item(ItemType.Sword, 1) );
    this.AddItem( new Item(ItemType.HealthPotion, 1) );
    this.AddItem( new Item(ItemType.ManaPotion, 1) );
    this.AddItem( new Item(ItemType.Sword, 1) );
    this.AddItem( new Item(ItemType.HealthPotion, 1) );
    this.AddItem( new Item(ItemType.ManaPotion, 1) );
    this.AddItem( new Item(ItemType.Sword, 1) );
    this.AddItem( new Item(ItemType.HealthPotion, 1) );
    this.AddItem( new Item(ItemType.ManaPotion, 1) );
    this.AddItem( new Item(ItemType.Sword, 1) );
    this.AddItem( new Item(ItemType.HealthPotion, 1) );
    this.AddItem( new Item(ItemType.ManaPotion, 1) );
    Debug.Log("itemList[0] amount is : " + this.itemList[0].amount);
  }

}