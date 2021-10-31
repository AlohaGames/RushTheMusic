using UnityEngine;

namespace Aloha
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
            Vector3 direction = new Vector3(0, 0, 2);
            StartCoroutine(entity.GetBump(direction, speed));
        }
    }
}