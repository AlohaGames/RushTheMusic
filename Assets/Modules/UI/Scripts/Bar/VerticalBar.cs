using UnityEngine;


namespace Aloha
{
    public class VerticalBar : Bar
    {
        override public void UpdateBar(int current, int max)
        {
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            float height = ((RectTransform)this.transform).rect.height;
            barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height * (float)current / (float)max);
        }
    }
}