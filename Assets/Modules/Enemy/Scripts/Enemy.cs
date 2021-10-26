using Aloha.Events;

namespace Aloha
{
    public class Enemy<T> : Entity<T> where T : EnemyStats
    {
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
    public class Enemy : Enemy<EnemyStats> { }
}
