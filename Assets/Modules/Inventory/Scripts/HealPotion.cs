using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// This class manage healing potion
    /// </summary>
    public class HealPotion : Item
    {
        private int hpGain;

        /// <summary>
        /// The constructor with a the number of life that will be regenerate
        /// <example> Example(s): 
        /// <code>
        ///     HealPotion healpotion = new HealPotion(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="hpGain"></param>
        public HealPotion(int hpGain)
        {
            this.hpGain = hpGain;
        }

        /// <summary>
        /// Call the hero and regenerate him with the value of the gain
        /// <example> Example(s): 
        /// <code>
        ///     healpotion.Effect();
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.hero_drink, this.gameObject
            );
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.health_potion_effect, this.gameObject, SoundEffectManager.Instance.Sounds.hero_drink.length
            );

            Hero hero = GameManager.Instance.GetHero();
            hero.RegenerateHP(this.hpGain);
        }
    }
}
