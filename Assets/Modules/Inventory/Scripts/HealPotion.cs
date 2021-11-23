using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class HealPotion : Item
    {
        private int hpGain;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="hpGain"></param>
        public HealPotion(int hpGain)
        {
            this.hpGain = hpGain;
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
            hero.RegenerateHP(this.hpGain);
        } 
    }
}
