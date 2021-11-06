using UnityEngine;
using Leap;


namespace Aloha
{
    public class Wizard : Hero<WarriorStats>
    {
        private int currentMana;
        public void Init(WizardStats stats)
        {
            base.Init(stats);
            this.currentMana = stats.maxMana;
        }
        public void BumpEntity(Entity entity)
        {
            Vector3 direction = new Vector3(0, 0, 2);
            StartCoroutine(entity.GetBump(direction, 1));
        }

    }
}