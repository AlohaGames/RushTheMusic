using UnityEngine;

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

    }
}