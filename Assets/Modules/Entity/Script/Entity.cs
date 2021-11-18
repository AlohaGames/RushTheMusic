using System.Collections;
using Aloha.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField]
        protected Stats stats;

        protected UnityEvent dieEvent = new UnityEvent();
        public int CurrentHealth;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <return>
        /// TODO
        /// </return>
        public Stats GetStats()
        {
            return this.stats;
        }

        /// <summary>
        /// This function is called when a entity attack another entity.
        /// <example> Example(s):
        /// <code>
        ///     anEntity.Attack(anotherEntity);
        /// </code>
        /// <code>
        ///     warrior.Attack(assassin);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Attack(Entity entity)
        {
            entity.TakeDamage(this.stats.Attack);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
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
        /// TODO
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
        /// This function is called when an entity taking damage amount.
        /// <example> Example(s):
        /// <code>
        ///     warrior.TakeDamage(5);
        /// </code>
        /// <code>
        ///     spearman.TakeDamage(2);
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
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="gain"></param>
        public virtual void Regeneration(int gain)
        {
            this.CurrentHealth += gain;
            if (CurrentHealth > GetStats().MaxHealth)
            {
                CurrentHealth = GetStats().MaxHealth;
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public IEnumerator GetBump(Vector3 direction, float speed = 2f)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit + direction;

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
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public virtual void Die()
        {
            dieEvent.Invoke();
            GlobalEvent.EntityDied.Invoke(this);
        }
    }
}
