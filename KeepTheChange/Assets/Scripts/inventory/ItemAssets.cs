using UnityEngine;

public class ItemAssets : MonoBehaviour {

  public static ItemAssets Instance { get; private set; }

  private void Awake() {
    Instance = this;
  }

  public Sprite SwordSprite { get { return swordSprite; } private set { swordSprite = value;}}
  [SerializeField] Sprite swordSprite;
  public Sprite HealthPotionSprite { get { return healthPotionSprite; } private set { healthPotionSprite = value;}}
  [SerializeField] Sprite healthPotionSprite;
  public Sprite ManaPotionSprite { get { return manaPotionSprite; } private set { manaPotionSprite = value;}}
  [SerializeField] Sprite manaPotionSprite;
  public Sprite Wood { get { return wood; } private set { wood = value;}}
  [SerializeField] Sprite wood;
  public Sprite PinkFruit { get { return pinkFruit; } private set { pinkFruit = value;}}
  [SerializeField] Sprite pinkFruit;
  public Sprite GreenShroom { get { return greenShroom; } private set { greenShroom = value;}}
  [SerializeField] Sprite greenShroom;
  public Sprite RedShroom { get { return redShroom; } private set { redShroom = value;}}
  [SerializeField] Sprite redShroom;
  public Sprite BrownShroom { get { return brownShroom; } private set { brownShroom = value;}}
  [SerializeField] Sprite brownShroom;
  public Sprite R_FirePotion { get { return r_FirePotion; } private set { r_FirePotion = value;}}
  [SerializeField] Sprite r_FirePotion;

}