using Aloha.EntityStats;

namespace Aloha.Hero
{
    public class Guerrier : Hero<GuerrierStats>
    {
        private int currentRage;
        public void Init(GuerrierStats stats)
        {
            base.Init(stats);
            this.currentRage = stats.maxRage;
        }
    }
}