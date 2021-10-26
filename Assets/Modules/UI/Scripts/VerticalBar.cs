using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha
{
    public class VerticalBar : Bar
    {
        override public void UpdateBar(int current, int max)
        {
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            barTransform.sizeDelta = new Vector2(barTransform.sizeDelta.x, barTransform.sizeDelta.y * ((float) current / (float) max));
        }
    }
}