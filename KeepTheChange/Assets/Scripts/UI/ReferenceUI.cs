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
  private Canvas _mainCanvas = null;
  public Canvas MainCanvas { get { return _mainCanvas; } }
  // _mainCanvas field is private with a public getter property to ensure it is read-only.
  [SerializeField]
  private InventoryUI _inventoryUI = null;
  public InventoryUI InventoryUI { get { return _inventoryUI; } }
  private Inventory _inventory;
  public Inventory Inventory { get { return _inventory; } set { _inventory = value; } }
  // quick way to make sure objects don't duplicate on re-entering main scene
  private Dictionary<string, bool> _dontDestroyObjects = new Dictionary<string, bool>();
  public Dictionary<string, bool> DontDestroyObjects { get { return _dontDestroyObjects; } set { _dontDestroyObjects = value; } }
  [SerializeField]
  private CraftingUI _craftingUI;
  public CraftingUI CraftingUI { get { return _craftingUI; } set { _craftingUI = value; } }

  public void AddDontDestroyObject( string name ) {
    this._dontDestroyObjects.Add(name, true);
  }

  public void ToggleCraftingUI() {
    this._craftingUI.gameObject.SetActive(!this._craftingUI.gameObject.activeSelf);
  }

  public void HideCraftingUI() {
    this._craftingUI.gameObject.SetActive(false);
  }

  private void Awake() {
    this.InitInventory();
  }

  private void InitInventory() {
    Inventory inv = new Inventory();
    this._inventory = inv;
  }

}
