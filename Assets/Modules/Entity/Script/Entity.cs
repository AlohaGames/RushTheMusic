using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    public class Entity<T> : MonoBehaviour where T : Stats
    {

        public T stats;
        public int currentHealth;
        public UnityEvent dieEvent;

        public void Init(Stats stats)
        {
            this.stats = (T) stats;
            this.currentHealth = stats.maxHealth;
        }

        public void Attack(Entity<Stats> entity)
        {
            entity.TakeDamage(this.stats.attack);
        }

        public virtual void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            dieEvent.Invoke();
        }
    }
}