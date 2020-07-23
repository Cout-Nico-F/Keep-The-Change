using UnityEngine;

public class RecipeAssets : MonoBehaviour {

  public static RecipeAssets Instance { get; private set; }

  private void Awake() {
    Instance = this;
  }

  [SerializeField] Recipe recipe;
  // [SerializeField] Sprite healthPotionSprite;
  // [SerializeField] Sprite manaPotionSprite;
  // [SerializeField] Sprite Wood;
  // [SerializeField] Sprite PinkFruit;
  // [SerializeField] Sprite GreenShroom;
  // [SerializeField] Sprite RedShroom;
  // [SerializeField] Sprite BrownShroom;

}