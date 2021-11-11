using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class SecondaryBar : HorizontalBar
    {
        /// <summary>
        /// TODO
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnSecondaryUpdate.AddListener(UpdateBar);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.OnSecondaryUpdate.RemoveListener(UpdateBar);
        }
    }
}
