using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{
    private SpriteRenderer parentRenderer;
    private int baseOrderInLayer;
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
            parentRenderer.sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parentRenderer.sortingOrder = baseOrderInLayer;
    }
}
