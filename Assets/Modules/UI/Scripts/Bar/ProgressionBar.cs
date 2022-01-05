using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the progression bar
    /// </summary>
    public class ProgressionBar : VerticalBar
    {
        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnProgressionUpdate.AddListener(UpdateBar);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.OnProgressionUpdate.RemoveListener(UpdateBar);
        }
    }
}
