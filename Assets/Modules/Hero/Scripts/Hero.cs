using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha.Hero
{
    public class Hero<T> : Entity<HeroStats> where T : HeroStats
    {
        public void Init(HeroStats stats)
        {
            base.Init(stats);
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
            return damageReduction = (stats.defense / (stats.defense + 20));
        }
    }
}
