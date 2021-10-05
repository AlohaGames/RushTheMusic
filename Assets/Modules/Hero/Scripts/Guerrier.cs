using EntityStats;

namespace Entities
{
    public class Guerrier : Hero<GuerrierStats>
    {
        private int fureur;
        public void Init(GuerrierStats stats)
        {
            Init((HeroStats)stats);
            this.fureur = stats.maxFureur;
        }
    }
}