using UnityEngine;
using UnityEngine.Events;
using EntityStats;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
    }
    public class Entity<T> : MonoBehaviour where T : Stats
    {

        public T stats;
        public int health;
        public int attack;
        public UnityEvent dieEvent;

        public void Init(T stats)
        {
            this.stats = stats;
            this.health = stats.maxHealth;
            this.attack = stats.attackPower;
        }

        public void Attack(Entity<Stats> entity)
        {
            entity.TakeDamage(this.stats.attackPower);
        }

        public virtual void TakeDamage(int damage)
        {
            int realDamage = (int)(damage);
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

        public void Die()
        {
            dieEvent.Invoke();
        }
    }
}