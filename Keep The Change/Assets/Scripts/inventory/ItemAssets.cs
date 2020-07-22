using UnityEngine;

public class ItemAssets : MonoBehaviour {

  public static ItemAssets Instance { get; private set; }

  private void Awake() {
    Instance = this;
  }

  public Sprite swordSprite;
  public Sprite healthPotionSprite;
  public Sprite manaPotionSprite;
  public Sprite Wood;
  public Sprite PinkFruit;
  public Sprite GreenShroom;
  public Sprite RedShroom;
  public Sprite BrownShroom;//can they be serializeField instead of public? is it better in any way? just for know

}