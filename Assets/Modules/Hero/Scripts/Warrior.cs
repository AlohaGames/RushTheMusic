using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class Warrior : Hero<WarriorStats>
    {
        //TODO: Ajouter une fonction de parade
        public int currentRage;
        private float REGENERATION_POURCENT = 0.2f;

        public override void Init()
        {
            this.Init(this.heroStats);
        }
        public void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.currentRage = 0;
            GlobalEvent.OnSecondaryUpdate.Invoke(this.currentRage, this.heroStats.maxRage);
        }

        public void BumpEntity(Entity entity, float speed)
        {
            Vector3 direction = new Vector3(0, 0, 2 * speed);
            StartCoroutine(entity.GetBump(direction, 2f));
        }

        //Regen x% of maxRage per hit
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            // Add limit to increasing of rage
            if (currentRage < this.heroStats.maxRage) currentRage = currentRage + (int)(heroStats.maxRage * REGENERATION_POURCENT);
            if (currentRage > this.heroStats.maxRage) currentRage = this.heroStats.maxRage;
            
            GlobalEvent.OnSecondaryUpdate.Invoke(this.currentRage, this.heroStats.maxRage);
        }

        public override void Attack(Entity entity)
        {
            int damage;
            if (this.currentRage == heroStats.maxRage)
            {
                Stats entityStats = entity.GetStats();
                damage = entityStats.maxHealth;
                entity.TakeDamage(damage);
                currentRage = 0;
                GlobalEvent.OnSecondaryUpdate.Invoke(this.currentRage, this.heroStats.maxRage);
            }
            else
            {
                damage = heroStats.attack;
                entity.TakeDamage(damage);
                currentRage = currentRage + (int)(heroStats.maxRage * REGENERATION_POURCENT);
                GlobalEvent.OnSecondaryUpdate.Invoke(this.currentRage, this.heroStats.maxRage);
            }
        }
    }
}
