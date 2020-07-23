using System;
using System.Collections.Generic;
using UnityEngine;

public class RecipeAssets : MonoBehaviour {

  public static RecipeAssets Instance { get; private set; }

  private void Awake() {
    Instance = this;
  }

  [SerializeField] List<Recipe> recipeList;
  
  [Serializable]
  public struct Recipe {
    [SerializeField] ItemType itemTypeA;
    [SerializeField] ItemType itemTypeB;
    [SerializeField] ItemType itemResult;
  }

}