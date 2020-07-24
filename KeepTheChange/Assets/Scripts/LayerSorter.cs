using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{
    private SpriteRenderer parentRenderer;
    private int baseOrderInLayer;
    private List<DynamicSorter> dynamicSorters = new List<DynamicSorter>();
    

    // Start is called before the first frame update
    void Start()
    {
        parentRenderer = transform.parent.GetComponent<SpriteRenderer>();
        baseOrderInLayer = parentRenderer.sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DynamicSorter")
        {
            DynamicSorter dyn = collision.GetComponent<DynamicSorter>();

            if(dynamicSorters.Count == 0 || dyn.MySpriteRenderer.sortingOrder -1 < parentRenderer.sortingOrder)
            {
                parentRenderer.sortingOrder = dyn.MySpriteRenderer.sortingOrder - 1;
            }

            dynamicSorters.Add(dyn);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "DynamicSorter")
        {
            DynamicSorter dyn = collision.GetComponent<DynamicSorter>();
            dynamicSorters.Remove(dyn);
            if(dynamicSorters.Count == 0)
            {
                parentRenderer.sortingOrder = baseOrderInLayer;
            }
            else
            {
                dynamicSorters.Sort();
                parentRenderer.sortingOrder = dynamicSorters[0].MySpriteRenderer.sortingOrder - 1;
            }
            
        }
        
    }
}
