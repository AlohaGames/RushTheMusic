using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class Entity : MonoBehaviour
    {
    }
    public class Entity<T> : MonoBehaviour where T : Stats
    {

        public T stats;

        public int health;        

        public UnityEvent dieEvent;


        public void Init(T stats){
            this.stats = stats;
        }

        public void Attack(Entity<Stats> entity)
        {
            entity.TakeDamage(this.stats.attackPower);
        }

        public void TakeDamage(int damage)
        {
            int realDamage = (int) (damage / this.stats.defensePower); //A redéfinir selon comment est stocké la défense
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

        private void Die(){
            dieEvent.Invoke();
        }
    }
}