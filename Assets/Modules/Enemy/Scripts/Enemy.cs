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
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public EnemyStats GetStats()
        {
            return this.enemyStats;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Awake()
        {
            this.dieEvent.AddListener(Disappear);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
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
