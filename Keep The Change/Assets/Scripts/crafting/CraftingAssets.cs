using UnityEngine;

public class CraftingAssets : MonoBehaviour {

  public static CraftingAssets Instance { get; private set; }

  private void Awake() {
    Instance = this;
  }

  // [SerializeField] Sprite swordSprite;
  // [SerializeField] Sprite healthPotionSprite;
  // [SerializeField] Sprite manaPotionSprite;
  // [SerializeField] Sprite Wood;
  // [SerializeField] Sprite PinkFruit;
  // [SerializeField] Sprite GreenShroom;
  // [SerializeField] Sprite RedShroom;
  // [SerializeField] Sprite BrownShroom;

}