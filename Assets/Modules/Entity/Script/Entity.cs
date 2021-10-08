using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Events;

namespace Aloha
{
    public abstract class Entity : MonoBehaviour
    {
        public int currentHealth;
        public int attack;
        protected UnityEvent dieEvent = new UnityEvent();

        public abstract void Init();

        public abstract void Attack(Entity entity);

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

        public void Die(){
            dieEvent.Invoke();
            GlobalEvent.EntityDied.Invoke(this);
        }

    }
    public abstract class Entity<T> : Entity where T : Stats
    {
        public T stats;
        public override void Attack(Entity entity)
        {
            entity.TakeDamage(this.stats.attack);
        }

        public override void Init()
        {
            this.Init(this.stats);
        }

        public virtual void Init(Stats stats)
        {
            this.stats = (T)stats;
            this.currentHealth = stats.maxHealth;
        }

    }
}