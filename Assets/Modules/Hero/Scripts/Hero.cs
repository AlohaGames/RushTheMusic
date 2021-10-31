using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Hero : Entity
    {
        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public virtual HeroStats GetStats()
        {
            return this.stats as HeroStats;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            Init(this.stats);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="stats"></param>
        public override void Init(Stats stats)
        {
            base.Init(stats);
            GlobalEvent.OnHealthUpdate.Invoke(this.CurrentHealth, stats.MaxHealth);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="xp"></param>
        public void LevelUp(int xp = 1)
        {
            this.GetStats().XP += xp;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            float damageReduction = CalculateDamageReduction();
            int realDamage = (int)(damage * (1 - damageReduction));
            base.TakeDamage(realDamage);
            GlobalEvent.OnHealthUpdate.Invoke(this.CurrentHealth, this.stats.MaxHealth);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public float CalculateDamageReduction()
        {
            float damageReduction;
            return damageReduction = (this.stats.Defense / (this.stats.Defense + 20));
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public class Hero<T> : Hero where T : HeroStats
    {
        private T heroStats
        {
            get { return this.stats as T; }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public override HeroStats GetStats()
        {
            return heroStats;
        }
    }
}
