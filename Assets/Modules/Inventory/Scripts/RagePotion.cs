namespace Aloha
{
    /// <summary>
    /// This class manage rage potion
    /// </summary>
    public class RagePotion : Item
    {
        private const float SECONDARY_REGENERATION = 0.1f;

        /// <summary>
        /// Give an effect to the rage potion. It regenerate the rage
        /// <example> Example(s):
        /// <code>
        ///     RagePotion ragePotion;
        ///     ragePotion.Effect();
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.hero_drink, this.gameObject
            );
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.rage_potion_effect, this.gameObject, SoundEffectManager.Instance.Sounds.hero_drink.length
            );

            Hero hero = GameManager.Instance.GetHero();
            hero.RegenerateSecondary(SECONDARY_REGENERATION);
        }
    }
}