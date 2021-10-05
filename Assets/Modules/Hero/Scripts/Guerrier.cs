using Aloha.EntityStats;

namespace Aloha.Hero
{
    public class Guerrier : Hero<GuerrierStats>
    {
        private int fureur;
        public new void Init(GuerrierStats stats)
        {
            base.Init(stats);
            this.fureur = stats.maxFureur;
        }
    }
}