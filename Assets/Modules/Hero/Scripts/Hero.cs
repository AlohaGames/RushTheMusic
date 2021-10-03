using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Heros
{
    public class Hero : MonoBehaviour
    {
        [SerializeField]
        public int health
        {
            get;
            private set;
        }

        public int xp
        {
            get;
            private set;
        }

        public int secondary
        {
            get;
            private set;
        }

        public int attackAmount
        {
            get;
            private set;
        }

        private int maxHealth;
        private int maxSecondary;

        public void Init(int maxHealth, int attackAmount)
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
        }
    }
}
