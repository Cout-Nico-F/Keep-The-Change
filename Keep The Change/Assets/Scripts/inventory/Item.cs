using UnityEngine;
using System;

public class Item {

  public ItemType itemType;
  public int amount;

  public Item( ItemType itemType, int amount ) {
    this.itemType = itemType;
    this.amount = amount;
  }

  public ItemType GetItemType() {
    return this.itemType;
  }

  public Sprite GetSprite() {
    
    switch ( this.itemType ) {
      default:
      case ItemType.Sword: return ItemAssets.Instance.SwordSprite;
      case ItemType.HealthPotion: return ItemAssets.Instance.HealthPotionSprite;
      case ItemType.ManaPotion: return ItemAssets.Instance.ManaPotionSprite;
      case ItemType.Wood: return ItemAssets.Instance.Wood;
      case ItemType.PinkFruit: return ItemAssets.Instance.PinkFruit;
      case ItemType.RedShroom: return ItemAssets.Instance.RedShroom;
      case ItemType.GreenShroom: return ItemAssets.Instance.GreenShroom;
      case ItemType.BrownShroom: return ItemAssets.Instance.BrownShroom;
      case ItemType.R_FirePotion: return ItemAssets.Instance.R_FirePotion;
    }
  }

  public override String ToString() {
    return "itemType : " + this.itemType.ToString() + " amount : " + this.amount;
  }

}