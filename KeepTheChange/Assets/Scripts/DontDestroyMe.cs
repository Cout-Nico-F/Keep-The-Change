using UnityEngine;
using System.Collections.Generic;

public class DontDestroyMe : MonoBehaviour {

  private void Awake() {
    string objName = this.gameObject.ToString();

    // quick way to deal with cleaning up any items that would be duplicated by this script
    if (!ReferenceUI.Instance.DontDestroyObjects.ContainsKey( objName )) {
      ReferenceUI.Instance.AddDontDestroyObject( objName );
      DontDestroyOnLoad( this.gameObject );
    } else {
      Destroy( this.gameObject );
    }

  }

}