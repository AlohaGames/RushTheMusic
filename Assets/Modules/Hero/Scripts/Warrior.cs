using UnityEngine;

namespace Aloha
{
    public class Warrior : Hero<WarriorStats>
    {
        //TODO: Ajouter une fonction de parade
        public int currentRage;
        private float REGENERATION_POURCENT = 0.2f;
        private float ATTACK_BONUS = 1.2f;
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

        //Regen x% of maxRage per hit
        public override void TakeDamage(int damage){
            base.TakeDamage(damage);
            currentRage = currentRage + (int)(stats.maxRage * REGENERATION_POURCENT);
        }

        public override void Attack(Entity entity)
        {
            int damage;
            if(this.currentRage == stats.maxRage){
                damage = entity.stats.maxHealth;
                entity.TakeDamage(damage);
                currentRage = 0;
            }else{
                damage = this.stats.attack;
                entity.TakeDamage(damage);
                currentRage = currentRage + (int)(stats.maxRage * REGENERATION_POURCENT);
            }
        }
    }
}