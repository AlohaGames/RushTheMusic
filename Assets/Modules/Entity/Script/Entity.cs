using UnityEngine;
using UnityEngine.Events;
using Aloha.Events;
using System.Collections;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        public int CurrentHealth;
        protected UnityEvent dieEvent = new UnityEvent();

        [SerializeField]
        protected Stats stats;
        

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        public void Attack(Entity entity)
        {
            entity.TakeDamage(this.stats.Attack);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public virtual void Init()
        {
            this.Init(this.stats);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="stats"></param>
        public virtual void Init(Stats stats)
        {
            this.stats = stats;
            this.CurrentHealth = this.stats.MaxHealth;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public virtual void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }
            CurrentHealth = CurrentHealth - damage;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
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

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void Die()
        {
            dieEvent.Invoke();
            GlobalEvent.EntityDied.Invoke(this);
        }
    }
}
