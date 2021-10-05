using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityStats;

namespace Entities
{
    public class Hero<T> : Entity<HeroStats> where T : HeroStats
    {
        public float defense;
        public void Init(T stats)
        {
            Init((HeroStats) stats);
            this.defense = stats.defensePower;
        }

        public void LevelUp(int xp = 1)
        {
            this.stats.xp += xp;
        }
        
        public override void TakeDamage(int damage)
        {
            int realDamage = (int) (damage / this.stats.defensePower);
            if (damage < 0)
            {
                return;
            }
            health = health - damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }
}
