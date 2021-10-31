using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Warrior : Hero<WarriorStats>
    {
        private const float REGENERATION_POURCENT = 0.2f;
        public int CurrentRage;

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
            Vector3 direction = new Vector3(0, 0, 2);
            StartCoroutine(entity.GetBump(direction, speed));
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
        public override void TakeDamage(int damage){
            base.TakeDamage(damage);
            CurrentRage = CurrentRage + (int)(heroStats.MaxRage * REGENERATION_POURCENT);
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
            }else{
                damage = heroStats.Attack;
                entity.TakeDamage(damage);
                CurrentRage = CurrentRage + (int)(heroStats.MaxRage * REGENERATION_POURCENT);
            }
        }
    }
}
