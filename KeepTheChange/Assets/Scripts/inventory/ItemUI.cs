using UnityEngine;

public class ItemUI : MonoBehaviour {

  [SerializeField] private ItemType itemType = ItemType.Sword;

  public void SetItemType( ItemType itemType ) {
    this.itemType = itemType;
  }

  public ItemType GetItemType() {
    return this.itemType;
  }

}