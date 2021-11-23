using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Aloha.AI;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Enemy<T> : Enemy where T : EnemyStats
    {
        private T enemyStats
        {
            get { return this.stats as T; }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public new EnemyStats GetStats()
        {
            return this.enemyStats;
        }
    }

    /// <summary>
    /// This class inherits from Entity. It manages the enemies.
    /// </summary>
    public class Enemy : Entity
    {
        [SerializeField]
        private bool noAI = false;

        protected bool AIActivated = false;

        public UnityEvent NearHeroTrigger = new UnityEvent();

        private EnemyStats enemyStats
        {
            get { return this.stats as EnemyStats; }
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
        public new EnemyStats GetStats()
        {
            return this.enemyStats;
        }

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
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
        /// TODO
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
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value"></param>
        public void SetAI(bool value)
        {
            if (!noAI)
            {
                AIActivated = value;
                if (AIActivated)
                {
                    //StartCoroutine(AI()); 
                    //GetComponent<GraphRunner>()?.StartGraph();
                }
                else
                {
                    GetComponent<GraphRunner>()?.StopGraph();
                }
            }
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            this.dieEvent.RemoveListener(Disappear);
        }
    }
}
