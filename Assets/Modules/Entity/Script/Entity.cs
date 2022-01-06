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
        private bool isDead = false;
        private bool isHitted = false;

        [SerializeField]
        protected Stats stats;
        protected UnityEvent dieEvent = new UnityEvent();

        public UnityEvent TakeDamageEvent = new UnityEvent();
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
            TakeDamageEvent.Invoke();
            if (damage < 0)
            {
                return;
            }

            ActionZone actionZone = GetComponentInChildren<ActionZone>();
            if (actionZone != null)
            {
                actionZone.WasTriggered = false;
            }

            if (!isHitted)
            {
                CurrentHealth = CurrentHealth - damage;
            }

            if (damage > 0)
            {
                if (CurrentHealth <= 0)
                {
                    if (!isDead)
                    {
                        StartCoroutine(SwitchColor());
                        isDead = true;
                        Die();
                    }
                }
                else
                {
                    StartCoroutine(SwitchColor());
                }
            }
        }

        /// <summary>
        /// Changes the color of the sprite and gives invincibility
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(SwitchColor());
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="hpGain"></param>
        /// <returns> IEnumerator </returns>
        IEnumerator SwitchColor()
        {
            isHitted = true;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite)
            {
                sprite.color = new Color(1f, 0.5f, 0.5f);
                yield return new WaitForSeconds(0.5f);
                sprite.color = Color.white;
            }
            isHitted = false;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="hpGain"></param>
        public virtual void RegenerateHP(int hpGain)
        {
            int newHealth = this.CurrentHealth + hpGain;
            this.CurrentHealth = newHealth.Clamp(0, this.GetStats().MaxHealth);
        }

        /// <summary>
        /// Bump the entity in a specific direction and with a speed
        /// <example> Example(s):
        /// <code>
        ///     entity.GetBump(new Vector3(0, 0, 2), 2);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public virtual IEnumerator GetBump(Vector3 direction, float speed = 2f)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit + direction;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;

                Vector3 tmpPos = Vector3.Lerp(posInit, posFinal, temps); ;
                tmpPos.y = posInit.y + Mathf.Sin(temps * Mathf.PI) * 0.25f;
                transform.position = tmpPos;

                yield return null;
            }
            gameObject.transform.position = posFinal;
            yield return null;
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
