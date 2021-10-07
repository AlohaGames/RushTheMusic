using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Events;

namespace Aloha
{
    public abstract class Entity : MonoBehaviour
    {
        public int health;
        public int attack;
        protected UnityEvent dieEvent = new UnityEvent();

        public abstract void Init();

        public abstract void Attack(Entity entity);

        /*public virtual void Attack(Object entity)
        {
            if (!(entity is Entity))
                return;
            Attack(entity as Entity);
        }*/

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
            GlobalEvent.EntityDied.Invoke(this);
        }
    }
    public abstract class Entity<T> : Entity where T : Stats
    {
        public T stats;
        public override void Attack(Entity entity)
        {
            entity.TakeDamage(this.stats.attackPower);
        }

        public override void Init()
        {
            this.Init(this.stats);
        }

        public virtual void Init(Stats stats)
        {
            this.stats = (T)stats;
            this.health = stats.maxHealth;
            this.attack = stats.attackPower;
        }
    }
}