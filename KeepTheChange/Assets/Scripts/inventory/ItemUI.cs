using UnityEngine;

public class ItemUI : MonoBehaviour {

  [SerializeField] private ItemType itemType = ItemType.Sword;

  public ItemType GetItemType() {
    return this.itemType;
  }

}