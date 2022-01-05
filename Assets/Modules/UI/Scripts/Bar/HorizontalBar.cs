using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the horizontal bar
    /// </summary>
    public class HorizontalBar : Bar
    {
        /// <summary>
        /// Update UI of the bar
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="current"></param>
        /// <param name="max"></param>
        public override void UpdateBar(int current, int max)
        {
            if (current > max) current = max;
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            float width = ((RectTransform)this.transform).rect.width;
            barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (float)current / (float)max);
        }
    }
}
