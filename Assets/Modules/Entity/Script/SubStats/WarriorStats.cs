using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for warrior's stats
    /// </summary>
    [CreateAssetMenu(fileName = "WarriorStats", menuName = "Stats/Hero/Warrior", order = 1)]
    public class WarriorStats : HeroStats
    {
        public int MaxRage;
    }
}
