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
  public Sprite Sticks { get { return sticks; } private set { sticks = value;}}
  [SerializeField] Sprite sticks;
  public Sprite Apple { get { return apple; } private set { apple = value; } }
  [SerializeField] Sprite apple;
  public Sprite Pumpkin { get { return pumpkin; } private set { pumpkin = value; } }
  [SerializeField] Sprite pumpkin;
  public Sprite Raw_PinkGem { get { return raw_pinkgem; } private set { raw_pinkgem = value; } }
  [SerializeField] Sprite raw_pinkgem;
  public Sprite Raw_GreenGem { get { return raw_greengem; } private set { raw_greengem = value; } }
  [SerializeField] Sprite raw_greengem;
  public Sprite Raw_blueGem { get { return raw_bluegem; } private set { raw_bluegem = value; } }
  [SerializeField] Sprite raw_bluegem;
  public Sprite DoubleShroom { get { return doubleshroom; } private set { doubleshroom = value; } }
  [SerializeField] Sprite doubleshroom;
  public Sprite Rock { get { return rock; } private set { rock = value; } }
  [SerializeField] Sprite rock;
  public Sprite FruitStick { get { return fruitstick; } private set { fruitstick = value; } }
  [SerializeField] Sprite fruitstick;

}