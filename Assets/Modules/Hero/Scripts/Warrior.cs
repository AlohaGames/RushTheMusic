using Aloha.EntityStats;

namespace Aloha.Hero
{
    public class Warrior : Hero<WarriorStats>
    {
        private int currentRage;
        public new void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.currentRage = stats.maxRage;
        }
    }
}