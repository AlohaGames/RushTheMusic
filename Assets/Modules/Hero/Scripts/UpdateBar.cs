using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBar : MonoBehaviour
{
    public Color color = Color.red;

    GameObject barObject;

    public void updateBar(float currentValue, float maxValue)
    {
        barObject = transform.GetChild(0).gameObject;
        RectTransform bar = barObject.GetComponent<RectTransform>();
        bar.sizeDelta = new Vector2(bar.sizeDelta.x * (currentValue/ maxValue), bar.sizeDelta.y);

    }


    public void test()
    {
        updateBar(50, 100);
    }
}
