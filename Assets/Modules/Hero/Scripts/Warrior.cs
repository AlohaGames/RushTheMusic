using Aloha.EntityStats;

namespace Aloha.Heros
{
    public class Warrior : Hero<WarriorStats>
    {
        private int currentRage;
        public void Init(WarriorStats stats)
        {
            base.Init(stats);
            this.currentRage = stats.maxRage;
        }
    }
}