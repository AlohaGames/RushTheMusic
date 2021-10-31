using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Aloha.Events
{
    /// <summary>
    /// TODO
    /// </summary>
    public class GlobalEvent
    {
        /// <summary>
        /// TODO
        /// </summary>
        public static UnityEvent Resume = new UnityEvent();

        /// <summary>
        /// TODO
        /// </summary>
        public static UnityEvent Pause = new UnityEvent();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="Entity"></param>
        public static EntityEvent EntityDied = new EntityEvent();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param></param>
        /// <param></param>
        public static IntIntEvent OnHealthUpdate = new IntIntEvent();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param></param>
        /// <param></param>
        public static IntIntEvent OnSecondaryUpdate = new IntIntEvent();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param></param>
        public static GameObjectEvent TileCount = new GameObjectEvent();

        /// <summary>
        /// TODO
        /// </summary>
        public static UnityEvent LevelStop = new UnityEvent();

        /// <summary>
        /// TODO
        /// </summary>
        public static UnityEvent LevelStart = new UnityEvent();

        /// <summary>
        /// Invoke when load level is request and will pass the string <paramref name="level" /> and the bool <paramref name="isTuto" />
        /// </summary>
        /// <param name="level">The level to load</param>
        /// <param name="isTuto">Is it a Tuto Level</param>
        public static StringBoolEvent LoadLevel = new StringBoolEvent();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param></param>
        public static HeroTypeEvent LoadHero = new HeroTypeEvent();

        /// <summary>
        /// TODO
        /// </summary>
        public static UnityEvent QuitGame = new UnityEvent();
    }
}
