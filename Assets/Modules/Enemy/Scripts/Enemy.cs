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

        public Hero Hero;

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
        void Awake()
        {
            // If hero is not set manually, get it from manager
            // Usefull for debug scenes
            if (!this.Hero)
            {
                this.Hero = GameManager.Instance.GetHero();
            }

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
            hero.GainXp(xpGain);

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
            Hero hero = GameManager.Instance.GetHero();
            if (hero)
            {
                gainHeroXp(hero);
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
