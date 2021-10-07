using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    public class Entity : Entity<Stats> {
        public override void Init() {
            this.Init(this.stats);
        }
     }
    public abstract class Entity<T> : MonoBehaviour where T : Stats
    {

        public T stats;
        public int health;
        public int attack;
        protected UnityEvent dieEvent = new UnityEvent();

        public void Init(Stats stats)
        {
            this.stats = (T)stats;
            this.health = stats.maxHealth;
            this.attack = stats.attackPower;
        }

        public abstract void Init();

        public virtual void Attack(Entity entity)
        {
            entity.TakeDamage(this.stats.attackPower);
        }

        public virtual void Attack(Object entity) {
            if(!(entity is Entity))
                return;
            Attack(entity as Entity);
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