using Aloha.EntityStats;
using UnityEngine;

namespace Aloha.Hero
{
    public class Warrior : Hero<WarriorStats>
    {
        private int currentRage;
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

        public override void TakeDamage(int damage){
            base.TakeDamage(damage);
            currentRage = currentRage;
        }

        public override void Attack(Enemy enemy)
        {
            base.Attack(enemy);
            currentRage = currentRage / 2;
        }
    }
}