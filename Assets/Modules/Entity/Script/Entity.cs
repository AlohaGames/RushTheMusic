using UnityEngine;
using UnityEngine.Events;
using Aloha.Events;
using System.Collections;

namespace Aloha
{
    public abstract class Entity : MonoBehaviour
    {
        public int currentHealth;
        public int attack;
        [SerializeField]
        protected Stats stats;
        protected UnityEvent dieEvent = new UnityEvent();

        public Stats GetStats(){
            return this.stats;
        }

        public virtual void Attack(Entity entity)
        {
            entity.TakeDamage(this.stats.attack);
        }

        public virtual void Init()
        {
            this.Init(this.stats);
        }

        public virtual void Init(Stats stats)
        {
            this.stats = stats;
            this.currentHealth = this.stats.maxHealth;
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

        public IEnumerator GetBump(Vector3 direction, float speed = 2f)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit + direction * speed;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                posFinal.y = posInit.y + Mathf.Sin(temps * Mathf.PI) * 0.25f;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }

            gameObject.transform.position = posFinal;
        }

        public void Die()
        {
            dieEvent.Invoke();
            GlobalEvent.EntityDied.Invoke(this);
        }

    }
}
