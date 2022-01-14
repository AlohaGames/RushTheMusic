using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// This class manage mana potion
    /// </summary>
    public class ManaPotion : Item
    {
        private const float SECONDARY_REGENERATION = 0.2f;

        /// <summary>
        /// Give an effect to the mana potion. It regenerate the mana.
        /// <example> Example(s):
        /// <code>
        ///     ManaPotion manaPotion;
        ///     manaPotion.Effect();
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.hero_drink, this.gameObject
            );
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.mana_potion_effect, this.gameObject, SoundEffectManager.Instance.Sounds.hero_drink.length
            );

            Hero hero = GameManager.Instance.GetHero();
            hero.RegenerateSecondary(SECONDARY_REGENERATION);
        }
    }
}