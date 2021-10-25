using UnityEngine.Events;

namespace Aloha.Events
{
    public class GlobalEvent
    {
        public static EntityEvent EntityDied = new EntityEvent();
        public static HeroEvent HeroTakeDamage = new HeroEvent();
        public static HeroEvent HeroDie = new HeroEvent();
        public static EnemyEvent EnemyDie = new EnemyEvent();
        public static GameObjectEvent TileCount = new GameObjectEvent();
        public static UnityEvent LevelStop = new UnityEvent();
    }
}
