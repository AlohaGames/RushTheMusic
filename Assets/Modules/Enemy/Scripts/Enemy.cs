using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        public int health
        {
            get;
            private set;
        }
        [SerializeField]
        private int maxHealth;

        public void Init(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
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
