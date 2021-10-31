namespace Aloha
{
    public class Enemy : Entity
    {
        protected EnemyStats enemyStats
        {
            get
            {
                return this.stats as EnemyStats;
            }
        }
        public new EnemyStats GetStats()
        {
            return this.enemyStats;
        }
        public void Awake()
        {
            this.dieEvent.AddListener(Disappear);
        }

        public override void Die()
        {
            base.Die();
        }

        public void Disappear()
        {
            Destroy(this.gameObject);
        }

        public void OnDestroy()
        {
            this.dieEvent.RemoveListener(Disappear);
        }
    }
}
