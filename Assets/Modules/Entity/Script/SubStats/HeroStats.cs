using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for hero's stats
    /// </summary>
    [CreateAssetMenu(fileName = "HeroStats", menuName = "Stats/Hero/Generic", order = 1)]
    public class HeroStats : Stats
    {
        public int XP;
        public int MaxXP;

        /// <summary>
        /// Scale the hero stats based on his level
        /// </summary>
        public void Scale()
        {
            this.Level += 1;

            // Each level need 20% more XP
            this.MaxXP = (int)(this.MaxXP * 1.20f);

            this.Attack = this.Attack + (Level * 2);
            this.Defense = this.Defense + (Level * 2);
            this.MaxHealth = this.MaxHealth + (Level * 2);
        }
    }
}
