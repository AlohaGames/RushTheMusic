using System;
using System.Collections;
using Aloha.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    /// <summary>
    /// Class for an enemy with stats
    /// </summary>
    public class Enemy<T> : Enemy where T : EnemyStats
    {
        private T enemyStats
        {
            get { return this.stats as T; }
        }

        /// <summary>
        /// Get stats from the ennemy
        /// <example> Example(s):
        /// <code>
        ///     ennemy.GetStats();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// Stats from the ennemy
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
        private EnemyStats enemyStats
        {
            get { return this.stats as EnemyStats; }
        }

        protected bool AIActivated = false;

        [SerializeField]
        Hero hero;
        public Hero Hero
        {
            get
            {
                if (!hero)
                {
                    hero = GameManager.Instance.GetHero();
                }
                return hero;
            }
            set
            {
                hero = value;
            }
        }

        [HideInInspector]
        public UnityEvent NearHeroTrigger = new UnityEvent();

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
        protected virtual void Awake()
        {
            this.dieEvent.AddListener(Disappear);
        }


        /// <summary>
        /// This function is called to give xp to the hero on enemy death
        /// <example> Example(s):
        /// <code>
        ///     myEnemyType.gainXP(myHero);
        /// </code>
        /// </example>
        /// </summary>
        private void gainHeroXp(Hero hero)
        {
            int xpGain = 25;

            // Hero get xp for each ennemy killed
            Hero.GainXp(xpGain);

            // Show XP Text
            DynamicTextManager.Instance.Show(gameObject, "+" + xpGain + " XP", Color.cyan);
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
            if (Hero)
            {
                gainHeroXp(Hero);
            }
            base.Die();
        }

        /// <summary>
        /// Destroy the ennemy without killing it.
        /// It will not update player's score
        /// <example> Example(s):
        /// <code>
        /// ennemy.Disappear();
        /// </code>
        /// </example>
        /// </summary>
        public void Disappear()
        {
            Debug.Log("Enemy >> Disappear");
            Destroy(this.gameObject, 0.5f);
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
