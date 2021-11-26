using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// This class manage the hero
    /// </summary>
    public class Hero : Entity
    {
        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public new virtual HeroStats GetStats()
        {
            return this.stats as HeroStats;
        }

        /// <summary>
        /// Initialize the hero
        /// <example> Example(s):
        /// <code>
        ///     hero.Init();
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            Init(this.stats);
        }

        /// <summary>
        /// Initialize the hero with stats
        /// <example> Example(s):
        /// <code>
        ///     hero.Init(heroStats);
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
        /// This function is called when a hero level up.
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="xp"></param>
        public void LevelUp(int xp = 1)
        {
            this.GetStats().XP += xp;
        }

        /// <summary>
        /// This function is called when a hero taking damage amount.
        /// <example> Example(s):
        /// <code>
        ///     warrior.TakeDamage(5);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            float damageReduction = CalculateDamageReduction();
            int realDamage = (int)(damage * (1 - damageReduction));
            base.TakeDamage(realDamage);
            GlobalEvent.HeroTakeDamage.Invoke();
            GlobalEvent.OnHealthUpdate.Invoke(this.CurrentHealth, this.stats.MaxHealth);

            if (this.CurrentHealth <= 0)
            {
                GlobalEvent.GameOver.Invoke();
            }
        }

        /// <summary>
        /// Regenerate HP of hero.
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public override void RegenerateHP(int hpGain)
        {
            base.RegenerateHP(hpGain);
            GlobalEvent.OnHealthUpdate.Invoke(this.CurrentHealth, this.stats.MaxHealth);
        }

        /// <summary>
        /// This function calculate damage reduction according to hero defense.
        /// <example> Example(s):
        /// <code>
        ///     float a = CalculateDamageReduction();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// A damage reduction float.
        /// </returns>
        public float CalculateDamageReduction()
        {
            float damageReduction;
            return damageReduction = (this.stats.Defense / (this.stats.Defense + 20));
        }

        /// <summary>
        /// Regenerate a pourcentage of secondary bar. The gain change depending on max secondary's hero
        /// </summary>
        /// <param name="secondaryRegen">A percentage of regeneration of the secondary bar</param>
        public virtual void RegenerateSecondary(float secondaryRegen){}

        /// <summary>
        /// Invoke Die event
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public override void Die()
        {
            base.Die();
            GlobalEvent.HeroDie.Invoke();
        }
    }

    /// <summary>
    /// This class manage the hero with stats
    /// </summary>
    public class Hero<T> : Hero where T : HeroStats
    {
        protected T heroStats
        {
            get{ return this.stats as T; }
        }

        /// <summary>
        /// This function get the stats of hero
        /// <example> Example(s):
        /// <code>
        ///     warrior.GetStats().MaxHealth;
        ///     warrior.GetStats().MaxRage;
        /// </code>
        /// <code>
        ///     wizard.GetStats().MaxHealth;
        ///     wizard.GetStats().MaxMana;
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        public new T GetStats()
        {
            return heroStats;
        }
    }
}
