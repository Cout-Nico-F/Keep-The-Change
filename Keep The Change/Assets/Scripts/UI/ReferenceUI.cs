using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // singleton static reference
    private static ReferenceUI _Instance;
    public static ReferenceUI Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<ReferenceUI>();
                if (_Instance == null)
                    Debug.LogError("There is no ReferenceUI in the scene!");
            }
            return _Instance;
        }
    }

    // assign this in the inspector
    [SerializeField]
    private Canvas _mainCanvas;
    public Canvas MainCanvas { get { return _mainCanvas; } }
    // _mainCanvas field is private with a public getter property to ensure it is read-only.
}
