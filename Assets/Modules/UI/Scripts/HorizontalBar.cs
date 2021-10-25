using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Heros;
using Aloha.EntityStats;


namespace Aloha
{
    public class HorizontalBar : Bar
    {
        override public void UpdateBar(int current, int max)
        {
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            barTransform.sizeDelta = new Vector2(barTransform.sizeDelta.x * ((float) current / (float) max), barTransform.sizeDelta.y);
        }
    }
}