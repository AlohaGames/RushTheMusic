using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.Heros
{
    public class Hero<T> : Entity<HeroStats> where T : HeroStats
    {
        /*public void Init(int maxHealth, int attackAmount)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.xp = 0;
            //this.maxSecondary = maxSecondary;
            //this.secondary = maxSecondary;
            this.attackAmount = attackAmount;
        }

        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(this.attackAmount);
            this.xp = xp + 1;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }
            health = health - damage;
            if (health <= 0)
            {
                DestroyImmediate(this.gameObject);
            }
        }*/
        public void Init(T stats)
        {
            Init((HeroStats) stats);
            this.health = stats.maxHealth;
        }

        public void LevelUp(int xp = 1)
        {
            this.stats.xp += xp;
        }
    }
}
