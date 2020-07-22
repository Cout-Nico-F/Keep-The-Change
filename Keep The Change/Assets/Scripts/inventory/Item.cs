using UnityEngine;

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
      case ItemType.Sword: return ItemAssets.Instance.swordSprite;
      case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
      case ItemType.ManaPotion: return ItemAssets.Instance.manaPotionSprite;
      case ItemType.Wood: return ItemAssets.Instance.Wood;
      case ItemType.PinkFruit: return ItemAssets.Instance.PinkFruit;
      case ItemType.RedShroom: return ItemAssets.Instance.RedShroom;
      case ItemType.GreenShroom: return ItemAssets.Instance.GreenShroom;
      case ItemType.BrownShroom: return ItemAssets.Instance.BrownShroom;
        }
  }

}