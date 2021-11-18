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
        /// Is called when the script instance is being loaded.
        /// </summary>
        new void Awake()
        {
            base.Awake();
            GlobalEvent.OnHealthUpdate.AddListener(UpdateBar);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.OnHealthUpdate.RemoveListener(UpdateBar);
        }
    }
}
