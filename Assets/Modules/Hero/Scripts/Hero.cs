using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class Hero : Entity
    {
        public new virtual HeroStats GetStats() {
            return this.stats as HeroStats;
        }
        public override void Init()
        {
            Init(this.stats);
        }
        public override void Init(Stats stats)
        {
            base.Init(stats);
            GlobalEvent.OnHealthUpdate.Invoke(this.currentHealth, stats.maxHealth);
        }

        public void LevelUp(int xp = 1)
        {
            this.GetStats().xp += xp;
        }

        public override void TakeDamage(int damage)
        {
            float damageReduction = CalculateDamageReduction();
            int realDamage = (int)(damage * (1 - damageReduction));
            base.TakeDamage(realDamage);
            GlobalEvent.OnHealthUpdate.Invoke(this.currentHealth, this.stats.maxHealth);
        }

        public float CalculateDamageReduction()
        {
            float damageReduction;
            return damageReduction = (this.stats.defense / (this.stats.defense + 20));
        }
    }
    public class Hero<T> : Hero where T : HeroStats
    {
        protected T heroStats
        {
            get
            {
                return this.stats as T;
            }
        }

        public new T GetStats()
        {
            return heroStats;
        }
    }
}
