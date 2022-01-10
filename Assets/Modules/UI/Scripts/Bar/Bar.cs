using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Class for a default bar
    /// </summary>
    public abstract class Bar : MonoBehaviour
    {
        protected GameObject bar;
        public Color Color; 

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        protected void Awake()
        {
            bar = transform.GetChild(0).gameObject;
            bar.GetComponent<Image>().color = Color;
        }

        /// <summary>
        /// Method called to update the bar
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
