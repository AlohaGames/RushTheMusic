using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// This class manage the warrior
    /// </summary>
    public class Warrior : Hero<WarriorStats>
    {
        //TODO: Ajouter une fonction de parade
        private const float REGENERATION_POURCENT = 0.2f;
        public int CurrentRage;
        public bool IsDefending;

        /// <summary>
        /// Initialize the warrior
        /// <example> Example(s):
        /// <code>
        ///     warrior.Init();
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            this.Init(this.heroStats);
            this.IsDefending = false;
        }

        /// <summary>
        /// Initialize the warrior with stats
        /// <example> Example(s):
        /// <code>
        ///     warrior.Init(warriorStats);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="stats"></param>
        public void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.CurrentRage = 0;
            this.IsDefending = false;
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
        }

        /// <summary>
        /// Bump an entity
        /// <example> Example(s):
        /// <code>
        ///     warrior.BumpEntity(assassin);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="speed"></param>
        public void BumpEntity(Entity entity, float speed)
        {
            Vector3 direction = new Vector3(0, 0, 2 * speed);
            StartCoroutine(entity.GetBump(direction, 2f));
        }

        /// <summary>
        /// This function makes the warrior take a certain amount of damage
        /// <example> Example(s):
        /// <code>
        ///     warrior.TakeDamage(50);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage">The amount of damage taken</param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            int newRage = CurrentRage + (int)(heroStats.MaxRage * REGENERATION_POURCENT);
            this.CurrentRage = newRage.Clamp(0, this.heroStats.MaxRage);

            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
        }

        /// <summary>
        /// The warrior attacks an entity
        /// <example> Example(s):
        /// <code>
        ///     warrior.Attack(wyrmling);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity">The entity type attacked</param>
        public override void Attack(Entity entity)
        {
            int damage;
            if (this.CurrentRage == heroStats.MaxRage)
            {
                Stats entityStats = entity.GetStats();
                damage = entityStats.MaxHealth;
                entity.TakeDamage(damage);
                CurrentRage = 0;
            }
            else
            {
                damage = heroStats.Attack;
                entity.TakeDamage(damage);
                CurrentRage = CurrentRage + (int)(heroStats.MaxRage * REGENERATION_POURCENT);
                GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
            }
        }

        /// <summary>
        /// Regenerates a pourcentage of the warrior's max rage.
        /// <example> Example(s):
        /// <code>
        ///     warrior.RegenerateSecondary();
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="secondaryRegen">A percentage of regeneration of the secondary bar</param>
        public override void RegenerateSecondary(float secondaryRegen)
        {
            int newRage = (int) (this.CurrentRage + this.heroStats.MaxRage * Mathf.Abs(secondaryRegen));
            this.CurrentRage = newRage.Clamp(0, this.heroStats.MaxRage);
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
        }
    }
}
