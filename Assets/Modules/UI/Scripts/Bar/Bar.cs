using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public abstract class Bar : MonoBehaviour
    {
        public Color Color;
        protected GameObject bar;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void Awake()
        {
            bar = transform.GetChild(0).gameObject;
            bar.GetComponent<Image>().color = Color;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="current"></param>
        /// <param name="max"></param>
        public abstract void UpdateBar(int current, int max);
    }
}
