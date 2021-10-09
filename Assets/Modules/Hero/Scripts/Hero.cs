using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Events;

namespace Aloha.Heros
{
    public class Hero : Hero<HeroStats>
    {

    }

    public class Hero<T> : Entity<T> where T : HeroStats
    {
        public override void Init(Stats stats)
        {
            base.Init(stats);
            currentHealth = stats.maxHealth;
        }

        public void LevelUp(int xp = 1)
        {
            this.stats.xp += xp;
        }
        public override void TakeDamage(int damage)
        {
            float damageReduction = CalculateDamageReduction();
            int realDamage = (int)(damage * (1 - damageReduction));
            base.TakeDamage(realDamage);
            GlobalEvent.HeroTakeDamage.Invoke();
        }
        public float CalculateDamageReduction()
        {
            float damageReduction;
            return damageReduction = (this.stats.defense / (this.stats.defense + 20));
        }
    }
}
