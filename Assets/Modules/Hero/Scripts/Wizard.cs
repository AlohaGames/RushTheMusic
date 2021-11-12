using UnityEngine;
using System.Collections;
using Aloha.Events;

namespace Aloha
{
    public class Wizard : Hero<WizardStats>
    {
        public int CurrentMana;

        public override void Init()
        {
            this.Init(this.heroStats);
        }
        public void Init(WizardStats stats)
        {
            base.Init(stats);
            this.CurrentMana = this.heroStats.MaxMana;
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
        }

        void Start()
        {
            StartCoroutine(RegainManaOverTime());
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
                power = this.heroStats.Attack;
                this.CurrentMana -= manaToUse;
            } else
            {
                power = this.heroStats.Attack * this.CurrentMana / manaToUse;
                this.CurrentMana = 0;
            }
            GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
            return power;
        }

        private IEnumerator RegainManaOverTime()
        {
            while (true)
            {
                if (this.CurrentMana < this.heroStats.MaxMana) this.CurrentMana += 10;
                GlobalEvent.OnSecondaryUpdate.Invoke(this.CurrentMana, this.heroStats.MaxMana);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}