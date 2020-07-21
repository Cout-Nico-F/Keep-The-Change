using UnityEngine;

public class ItemUI : MonoBehaviour {

  [SerializeField] private ItemType itemType;

  public ItemType GetItemType() {
    return this.itemType;
  }

}