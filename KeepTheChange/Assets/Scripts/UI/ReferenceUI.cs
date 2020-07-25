using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceUI : MonoBehaviour {

  // singleton static reference
  private static ReferenceUI _Instance;
  public static ReferenceUI Instance {
    get {
      if (_Instance == null) {
        _Instance = FindObjectOfType<ReferenceUI>();
        if (_Instance == null) {
          Debug.LogError("There is no ReferenceUI in the scene!");
        }
      }
      return _Instance;
    }
  }

  // assign this in the inspector
  [SerializeField]
  private Canvas _mainCanvas;
  public Canvas MainCanvas { get { return _mainCanvas; } }
  // _mainCanvas field is private with a public getter property to ensure it is read-only.
  [SerializeField]
  private InventoryUI _inventoryUI;
  public InventoryUI InventoryUI { get { return _inventoryUI; } }
  private Inventory _inventory;
  public Inventory Inventory { get { return _inventory; } set { _inventory = value; } }
    
  private void Awake() {
    print("--[ ReferenceUI Init ]--");
    this.InitInventory();
  }

  private void InitInventory() {
    Inventory inv = new Inventory();
    this._inventory = inv;
  }

}
