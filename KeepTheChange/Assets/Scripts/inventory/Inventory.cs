using System.Collections.Generic;
using UnityEngine;

public class Inventory {

  private List<Item> itemList;

  public Inventory() {
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

  private void SubtractFromAmount( ItemType type ) {
    int idx = 0;
    foreach (Item i in this.itemList) {
      if (i.GetItemType().Equals(type)) {
        i.amount--;
        if (i.amount == 0) {
          this.itemList.RemoveAt(idx);
          return;
        }
      }
      idx++;
    }
  }

  //@Todo subtract using item.amount
  public void AddItem( Item item ) {
    if (this.ContainsItem(item)) {
      this.AddToAmount(item.GetItemType());
    } else {
      this.itemList.Add(item);
    }
  }

  public void SubtractItem( Item item ) {
    if (this.ContainsItem(item)) {
      this.SubtractFromAmount(item.GetItemType());
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
  }

  public void PrintItems() {
    foreach (Item item in this.itemList) {
      Debug.Log("item: " + item.ToString());
    }
  }

}
