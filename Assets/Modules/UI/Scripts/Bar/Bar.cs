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
        [SerializeField]
        protected Image bar;

        [SerializeField]
        protected Text text;

        [SerializeField]
        protected bool isValueDesplayed = false;

        public Color Color; 

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        protected void Awake()
        {
            bar.color = Color;
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
