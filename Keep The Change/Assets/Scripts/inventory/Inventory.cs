using System.Collections.Generic;
using UnityEngine;

public class Inventory {

  private List<Item> itemList;

  public Inventory() {
    Debug.Log("inventory instantiated...");
    itemList = new List<Item>();

    this.AddDummyItems();
  }

  private void AddDummyItems() {
    this.AddItem( new Item { itemType = Item.ItemType.Sword, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.Sword, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.Sword, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.Sword, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
    this.AddItem( new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
  }

  public void AddItem( Item item ) {
    this.itemList.Add(item);
  }

  public List<Item> GetItems() {
    return this.itemList;
  }

}