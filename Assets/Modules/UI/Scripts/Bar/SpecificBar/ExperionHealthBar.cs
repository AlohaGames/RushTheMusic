using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the experion's bar
    /// </summary>
    public class ExperionHealthBar : HorizontalBar
    {

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            Experion experion = GetComponentInParent<Experion>();
            experion.OnHealthUpdate.AddListener(UpdateBar);
        }
    }
}
