using UnityEngine;
using System.Collections.Generic;

public class CookingUI : CraftingUI
{
    private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C))
    {
      this.DemoRecipe();
    }
  }

  private bool DemoRecipe()
  {
    ItemType demoTypeA = ItemType.Carrot;
    ItemType demoTypeB = ItemType.WoodenBowl;

    if (this.hasItems(demoTypeA, demoTypeB))
    {
      // remove those items from player inventory
      this.playerInventoryUI.SubtractItem(new Item(demoTypeA, 1));
      this.playerInventoryUI.SubtractItem(new Item(demoTypeB, 1));
      // add crafted item to player inventory
      this.playerInventoryUI.AddItem(new Item(ItemType.CarrotSoup, 1));
      
    }
    else
    {
      print("player inventory missing items");
    }

    return true;
  }

  private bool TryCook(ItemType ingredient1, ItemType ingredient2, ItemType result)
  {
    if (this.hasItems(ingredient1, ingredient2))
    {
      // remove those items from player inventory
      this.playerInventoryUI.SubtractItem(new Item(ingredient1, 1));
      this.playerInventoryUI.SubtractItem(new Item(ingredient2, 1));
      // add crafted item to player inventory
      this.playerInventoryUI.AddItem(new Item(result, 1));
    }
    else
    {
      print("player inventory missing items");
    }

    return true;
  }

}