using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for entity's stats
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/Enemy/Generic", order = 1)]
    public class EnemyStats : Stats
    {
        /// <summary>
        /// Scale the enemy stats based on a level
        /// </summary>
        public void Scale(int level)
        {
            this.Attack = this.Attack + (level * 3);
            this.Defense = this.Defense + (level * 3);
            this.MaxHealth = this.MaxHealth + (level * 3);
            this.Level = level;
        }
    }
}
