using UnityEngine;
using Leap;


namespace Aloha
{
    public class Wizard : Hero<WarriorStats>
    {
        public int currentMana;
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

        public int ChargeFireball()
        {
            int manaToUse = 200;
            int power = 0;

            if (this.currentMana >= manaToUse)
            {
                power = this.attack;
                this.currentMana -= manaToUse;
            } else
            {
                power = this.attack * this.currentMana / manaToUse;
                this.currentMana = 0;
            }
            return power;
        }
    }
}