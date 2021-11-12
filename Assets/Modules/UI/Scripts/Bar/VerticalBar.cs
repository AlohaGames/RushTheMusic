using UnityEngine;


namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class VerticalBar : Bar
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
        override public void UpdateBar(int current, int max)
        {
            if (current > max) current = max;
            RectTransform barTransform = bar.GetComponent<RectTransform>();
            float height = ((RectTransform)this.transform).rect.height;
            barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height * (float)current / (float)max);
        }
    }
}