using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha.Hero
{
    public class Hero<T> : Entity<T> where T : HeroStats
    {
        public float defense;
        public void Init(T stats)
        {
            base.Init(stats);
            this.defense = stats.defensePower;
        }

        public override void Init() {
            this.Init(stats);
        }

        public void LevelUp(int xp = 1)
        {
            this.stats.xp += xp;
        }
        
        public override void TakeDamage(int damage)
        {
            float damageReduction = CalculateDamageReduction();
            int realDamage = (int) (damage * (1 - damageReduction));
            base.TakeDamage(realDamage);
        }

        public float CalculateDamageReduction(){
            float damageReduction;
            return damageReduction = (this.stats.defense / (stats.defense + 20));
        }
    }
}
