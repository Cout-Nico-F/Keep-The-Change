﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] float fadeSpeed = 1f;
    [SerializeField] AnimationCurve curve = null;
    [SerializeField] string colliderFadesTo = null;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    private Image GetFaderImage()
    {
        return GameObject.Find("Fading").GetComponent<Image>();
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * fadeSpeed;
            float a = curve.Evaluate(t);
            this.GetFaderImage().color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            float a = curve.Evaluate(t);
            this.GetFaderImage().color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colliderFadesTo.Equals("ShopInterior"))
        {
            // store reference to player inventory
            ReferenceUI.Instance.Inventory = ReferenceUI.Instance.InventoryUI.GetComponent<InventoryUI>().GetInventory();
        }
        FadeTo(colliderFadesTo);
    }
}
