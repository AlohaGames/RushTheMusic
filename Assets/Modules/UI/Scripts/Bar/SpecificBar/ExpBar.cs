using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Experience bar
    /// </summary>
    public class ExpBar : HorizontalBar
    {
        [SerializeField]
        private Text levelText;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnExperienceUpdate.AddListener(UpdateXP);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.OnExperienceUpdate.RemoveListener(UpdateXP);
        }

        /// <summary>
        /// Update experience bar
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="level"></param>
        /// <param name="current"></param>
        /// <param name="max"></param>
        public void UpdateXP(int level, int currentXp, int maxXp)
        {
            levelText.text = level.ToString();
            base.UpdateBar(currentXp, maxXp);
        }
    }
}
