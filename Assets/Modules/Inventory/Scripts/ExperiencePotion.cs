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
        ///     ExperiencePotion experiencePotion;
        ///     experiencePotion.Effect();
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.hero_drink
            );
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.xp_potion_effect, null, SoundEffectManager.Instance.Sounds.hero_drink.length
            );

            Hero hero = GameManager.Instance.GetHero();
            hero.GainXp(hero.GetStats().MaxXP);
        }
    }
}
