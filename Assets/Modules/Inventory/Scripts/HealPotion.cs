using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class HealPotion : Item
    {
        private int gain;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="gain"></param>
        public HealPotion(int gain)
        {
            this.gain = gain;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            Hero hero = GameManager.Instance.GetHero();
            hero.Regeneration(this.gain);
        } 
    }
}
