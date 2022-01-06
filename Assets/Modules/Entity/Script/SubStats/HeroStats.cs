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
    }
}
