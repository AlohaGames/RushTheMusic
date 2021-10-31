using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class HealthBar : HorizontalBar
    {
        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnHealthUpdate.AddListener(UpdateBar);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.OnHealthUpdate.RemoveListener(UpdateBar);
        }
    }
}
