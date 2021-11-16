namespace Aloha
{
    /// <summary>
    /// This class manage mana potion
    /// </summary>
    public class ManaPotion : Item
    {
        private const float SECONDARY_REGENERATION = 0.2f;

        /// <summary>
        /// Give an effect to the mana potion. It regenerate the mana
        /// <example> Example(s):
        /// <code>
        ///     wizard.Effect();
        /// </code>
        /// </example>
        /// </summary>
        public override void Effect()
        {
            Hero hero = GameManager.Instance.GetHero();
            hero.RegenerateSecondary(SECONDARY_REGENERATION);
        }
    }
}