using UnityEngine;

public class ItemAssets : MonoBehaviour
{

    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite SwordSprite { get { return swordSprite; } private set { swordSprite = value; } }
    [SerializeField] Sprite swordSprite;
    public Sprite HealthPotionSprite { get { return healthPotionSprite; } private set { healthPotionSprite = value; } }
    [SerializeField] Sprite healthPotionSprite;
    public Sprite ManaPotionSprite { get { return manaPotionSprite; } private set { manaPotionSprite = value; } }
    [SerializeField] Sprite manaPotionSprite;
    public Sprite Wood { get { return wood; } private set { wood = value; } }
    [SerializeField] Sprite wood;
    public Sprite PinkFruit { get { return pinkFruit; } private set { pinkFruit = value; } }
    [SerializeField] Sprite pinkFruit;
    public Sprite GreenShroom { get { return greenShroom; } private set { greenShroom = value; } }
    [SerializeField] Sprite greenShroom;
    public Sprite RedShroom { get { return redShroom; } private set { redShroom = value; } }
    [SerializeField] Sprite redShroom;
    public Sprite BrownShroom { get { return brownShroom; } private set { brownShroom = value; } }
    [SerializeField] Sprite brownShroom;
    public Sprite R_FirePotion { get { return r_FirePotion; } private set { r_FirePotion = value; } }
    [SerializeField] Sprite r_FirePotion;
    public Sprite Sticks { get { return sticks; } private set { sticks = value; } }
    [SerializeField] Sprite sticks;
    public Sprite DoubleShroom { get { return doubleShroom; } private set { doubleShroom = value; } }
    [SerializeField] Sprite doubleShroom;
    public Sprite Pumpkin { get { return pumpkin; } private set { pumpkin = value; } }
    [SerializeField] Sprite pumpkin;
    public Sprite Turnip { get { return turnip; } private set { turnip = value; } }
    [SerializeField] Sprite turnip;
    public Sprite Cherry { get { return cherry; } private set { cherry = value; } }
    [SerializeField] Sprite cherry;
    public Sprite Eggplant { get { return eggplant; } private set { eggplant = value; } }
    [SerializeField] Sprite eggplant;
    public Sprite Carrot { get { return carrot; } private set { carrot = value; } }
    [SerializeField] Sprite carrot;
    public Sprite AppleJuice { get { return appleJuice; } private set { appleJuice = value; } }
    [SerializeField] Sprite appleJuice;
    public Sprite CherryJuice { get { return cherryJuice; } private set { cherryJuice = value; } }
    [SerializeField] Sprite cherryJuice;
    public Sprite BlueGem { get { return blueGem; } private set { blueGem = value; } }
    [SerializeField] Sprite blueGem;
    public Sprite WoodenBowl { get { return woodenBowl; } private set { woodenBowl = value; } }
    [SerializeField] Sprite woodenBowl;
    public Sprite ShroomSoup { get { return shroomSoup; } private set { shroomSoup = value; } }
    [SerializeField] Sprite shroomSoup;
    public Sprite CarrotSoup { get { return carrotSoup; } private set { carrotSoup = value; } }
    [SerializeField] Sprite carrotSoup;
    public Sprite LeafSoup { get { return leafSoup; } private set { leafSoup = value; } }
    [SerializeField] Sprite leafSoup;
    public Sprite GreenGem { get { return greenGem; } private set { greenGem = value; } }
    [SerializeField] Sprite greenGem;
    public Sprite PinkGem { get { return pinkGem; } private set { pinkGem = value; } }
    [SerializeField] Sprite pinkGem;
    public Sprite SlimeBurger { get { return slimeBurger; } private set { slimeBurger = value; } }
    [SerializeField] Sprite slimeBurger;

}