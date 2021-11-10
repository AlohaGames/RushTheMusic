using UnityEngine;
using Leap;


namespace Aloha
{
    public class Wizard : Hero<WarriorStats>
    {
        public int CurrentMana;

        public void Init(WizardStats stats)
        {
            base.Init(stats);
            this.CurrentMana = stats.maxMana;
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

            if (this.CurrentMana >= manaToUse)
            {
                power = this.attack;
                this.CurrentMana -= manaToUse;
            } else
            {
                power = this.attack * this.CurrentMana / manaToUse;
                this.CurrentMana = 0;
            }
            return power;
        }
    }
}