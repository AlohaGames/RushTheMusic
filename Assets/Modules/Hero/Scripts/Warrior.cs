using Aloha.EntityStats;
using UnityEngine;

namespace Aloha.Hero
{
    public class Warrior : Hero<WarriorStats>
    {
        //TODO: Ajouter une fonction de parade
        public int currentRage;
        private int REGENERATION_POURCENT = 20;
        public void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.currentRage = stats.maxRage;
        }

        public void BumpEntity(Entity entity, float speed)
        {
            Vector3 direction = new Vector3(0,0,2);
            StartCoroutine(entity.GetBump(direction,speed));
        }

        //Regen 10% of maxRage per hit
        public override void TakeDamage(int damage){
            base.TakeDamage(damage);
            currentRage = currentRage + (int)(stats.maxRage * (REGENERATION_POURCENT/100f));
        }

        public override void Attack(Entity entity)
        {
            base.Attack(entity);
            currentRage = currentRage / 2;
        }
    }
}