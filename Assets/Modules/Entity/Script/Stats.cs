using UnityEngine;

namespace EntityStats
{
    public class Stats : ScriptableObject{
        public int maxHealth;
        public int attackPower;
        public float defensePower;
        public int level;
    }

    public class HeroStats : Stats {
        public int xp;
        public int maxSecondary;
    }
}