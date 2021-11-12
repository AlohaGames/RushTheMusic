using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Warrior : Hero<WarriorStats>
    {
        //TODO: Ajouter une fonction de parade
        private const float REGENERATION_POURCENT = 0.2f;
        public int CurrentRage;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public override void Init()
        {
            this.Init(this.heroStats);
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
        public void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.CurrentRage = 0;
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="speed"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public void BumpEntity(Entity entity, float speed)
        {
            Vector3 direction = new Vector3(0, 0, 2 * speed);
            StartCoroutine(entity.GetBump(direction, 2f));
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            //TODO: voir si un clamp serait mieux
            // Add limit to increasing of rage
            if (CurrentRage < this.heroStats.MaxRage) CurrentRage = CurrentRage + (int)(heroStats.MaxRage * REGENERATION_POURCENT);
            if (CurrentRage > this.heroStats.MaxRage) CurrentRage = this.heroStats.MaxRage;
            
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        public override void Attack(Entity entity)
        {
            int damage;
            if(this.CurrentRage == heroStats.MaxRage){
                Stats entityStats = entity.GetStats();
                damage = entityStats.MaxHealth;
                entity.TakeDamage(damage);
                CurrentRage = 0;
            }else
            {
                damage = heroStats.Attack;
                entity.TakeDamage(damage);
                CurrentRage = CurrentRage + (int)(heroStats.MaxRage * REGENERATION_POURCENT);
                GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentRage, this.heroStats.MaxRage);
            }
        }
    }
}
