using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Hero : Entity {
        public virtual HeroStats GetStats() {
            return this.stats as HeroStats;
        }
    }
    public class Hero<T> : Hero where T : HeroStats
    {
        private T heroStats
        {
            get
            {
                return this.stats as T;
            }
        }
        public override HeroStats GetStats()
        {
            return heroStats;
        }
        public override void Init(Stats stats)
        {
            base.Init(stats);
            currentHealth = stats.maxHealth;
        }

        public void LevelUp(int xp = 1)
        {
            this.heroStats.xp += xp;
        }

        public override void TakeDamage(int damage)
        {
            float damageReduction = CalculateDamageReduction();
            int realDamage = (int)(damage * (1 - damageReduction));
            base.TakeDamage(realDamage);
        }

        public float CalculateDamageReduction()
        {
            float damageReduction;
            return damageReduction = (this.stats.defense / (this.stats.defense + 20));
        }
    }
}
