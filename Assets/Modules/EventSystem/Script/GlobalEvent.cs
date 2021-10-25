using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Aloha.Events
{
    public class GlobalEvent
    {

        public static UnityEvent Resume = new UnityEvent();
        public static UnityEvent Pause = new UnityEvent();
        public static EntityEvent EntityDied = new EntityEvent();
        public static GameObjectEvent TileCount = new GameObjectEvent();
        public static UnityEvent LevelStop = new UnityEvent();
        public static UnityEvent LevelStart = new UnityEvent();

        /// <summary>
        /// Invoke when load level is request and will pass the string <paramref name="level" /> and the bool <paramref name="isTuto" />
        /// </summary>
        /// <param name="level">The level to load</param>
        /// <param name="isTuto">Is it a Tuto Level</param>
        public static StringBoolEvent LoadLevel = new StringBoolEvent();
        public static HeroTypeEvent LoadHero = new HeroTypeEvent();
    }
}
