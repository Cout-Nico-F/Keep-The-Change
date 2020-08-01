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
      case ItemType.Sticks: return ItemAssets.Instance.Sticks;
      case ItemType.DoubleShroom: return ItemAssets.Instance.DoubleShroom;
      case ItemType.Pumpkin: return ItemAssets.Instance.Pumpkin;
      case ItemType.Turnip: return ItemAssets.Instance.Turnip;          
      case ItemType.Cherry: return ItemAssets.Instance.Cherry;
      case ItemType.Eggplant: return ItemAssets.Instance.Eggplant;
      case ItemType.Carrot: return ItemAssets.Instance.Carrot;
      case ItemType.AppleJuice: return ItemAssets.Instance.AppleJuice;
      case ItemType.CherryJuice: return ItemAssets.Instance.CherryJuice;
      case ItemType.BlueGem: return ItemAssets.Instance.BlueGem;
      case ItemType.GreenGem: return ItemAssets.Instance.GreenGem;
      case ItemType.PinkGem: return ItemAssets.Instance.PinkGem;
      case ItemType.WoodenBowl: return ItemAssets.Instance.WoodenBowl;
      case ItemType.ShroomSoup: return ItemAssets.Instance.ShroomSoup;
      case ItemType.CarrotSoup: return ItemAssets.Instance.CarrotSoup;
      case ItemType.LeafSoup: return ItemAssets.Instance.LeafSoup;
      case ItemType.SlimeBurger: return ItemAssets.Instance.SlimeBurger;
        }
  }

  public override String ToString() {
    return "itemType : " + this.itemType.ToString() + " amount : " + this.amount;
  }

}