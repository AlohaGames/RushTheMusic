using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// This class manage experience potion
    /// </summary>
    public class ExperiencePotion : Item
    {
        private const float SECONDARY_REGENERATION = 0.2f;

        /// <summary>
        /// Give an effect to the experience potion. It gives a level of xp.
        /// <example> Example(s):
        /// <code>
        ///     ManaPotion manaPotion;
        ///     manaPotion.Effect();
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            Hero hero = GameManager.Instance.GetHero();
            hero.LevelUp(hero.GetStats().MaxXP);
        }
    }
}