using UnityEngine;

namespace Aloha
{
    public class HorizontalBar : Bar
    {
        public override void UpdateBar(int current, int max)
        {
            if (current > max) current = max;
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            float width = ((RectTransform)this.transform).rect.width;
            barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (float)current / (float)max);
        }
    }
}
