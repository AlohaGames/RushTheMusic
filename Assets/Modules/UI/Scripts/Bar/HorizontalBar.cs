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
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            float width = ((RectTransform)this.transform).rect.width;
            barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * (float)current / (float)max);
        }
    }
}
