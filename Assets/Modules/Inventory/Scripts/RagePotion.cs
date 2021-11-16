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
        ///     warrior.Effect();
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