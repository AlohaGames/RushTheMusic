using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the secondary bar
    /// </summary>
    public class SecondaryBar : HorizontalBar
    {
        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnSecondaryUpdate.AddListener(UpdateBar);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.OnSecondaryUpdate.RemoveListener(UpdateBar);
        }
    }
}
