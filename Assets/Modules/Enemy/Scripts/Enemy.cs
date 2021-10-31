using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Enemy : Entity
    {
        private EnemyStats enemyStats
        {
            get{ return this.stats as EnemyStats; }
        }

        /// <summary>
        /// This function get the stats of enemy.
        /// <example> Example(s):
        /// <code>
        ///     enemy.GetStats().MaxHealth;
        ///     enemy.GetStats().Attack;
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// A EnemyStats from enemy.
        /// </returns>
        public EnemyStats GetStats()
        {
            return this.enemyStats;
        }

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public void Awake()
        {
            this.dieEvent.AddListener(Disappear);
        }

        /// <summary>
        /// This function is called when an enemy died. It inherite from entity class.
        /// <example> Example(s):
        /// <code>
        ///     myEnemyType.Die();
        /// </code>
        /// </example>
        /// </summary>
        public override void Die()
        {
            base.Die();
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void Disappear()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void OnDestroy()
        {
            this.dieEvent.RemoveListener(Disappear);
        }
    }
}
