using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class HorizontalBar : Bar
    {
        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="current"></param>
        /// <param name="max"></param>
        public override void UpdateBar(int current, int max)
        {
            Debug.Log("Current : " + current + ", max : " + max);
            if (current > max) current = max;
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            float width = ((RectTransform)this.transform).rect.width;
            barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (float)current / (float)max);
            Debug.Log("width * (float)current / (float) : " + width * (float)current / (float)max);
        }
    }
}
