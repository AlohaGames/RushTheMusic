using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for entity's stats
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/Enemy/Generic", order = 1)]
    public class EnemyStats : Stats
    {
        public void Scale(int level)
        {
            this.Attack = this.Attack + (level * 2);
            this.Defense = this.Defense + (level * 2);
            this.MaxHealth = this.MaxHealth + (level * 2);
            this.Level = level;
        }
    }
}
