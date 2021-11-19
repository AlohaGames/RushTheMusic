using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// The item for heal the Hero
    /// </summary>
    public class HealPotion : Item
    {
        private int gain;

        /// <summary>
        /// The constructor with a the number of life that will be regenerate
        /// </summary>
        /// <param name="gain"></param>
        public HealPotion(int gain)
        {
            this.gain = gain;
        }

        /// <summary>
        /// Call the hero and regenerate him with the value of the gain
        /// </summary>
        public override void Effect()
        {
            Hero hero = GameManager.Instance.GetHero();
            hero.Regeneration(this.gain);
        } 
    }
}
