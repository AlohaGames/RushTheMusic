using UnityEngine.Events;
using UnityEngine;
using System.Collections;

namespace Aloha.Events
{
    /// <summary>
    /// Class which regroup every game events
    /// </summary>
    public class GlobalEvent
    {
        /// <summary>
        /// Basic UnityEvent invoke when Resume the game is request
        /// </summary>
        public static UnityEvent Resume = new UnityEvent();

        /// <summary>
        /// Basic UnityEvent invoke when Pause the game is request
        /// </summary>
        public static UnityEvent Pause = new UnityEvent();

        /// <summary>
        /// Event called when an entity dies
        /// </summary>
        /// <param name="Entity"></param>
        public static EntityEvent EntityDied = new EntityEvent();

        /// <summary>
        /// Event called when the hero takes damages
        /// </summary>
        public static UnityEvent HeroTakeDamage = new UnityEvent();

        /// <summary>
        /// Event called when the hero dies
        /// </summary>
        public static UnityEvent HeroDie = new UnityEvent();

        /// <summary>
        /// Event called when an enemy dies
        /// </summary>
        public static UnityEvent EnemyDie = new UnityEvent();

        /// <summary>
        /// Event called when hero's health is updated 
        /// </summary>
        /// <param></param>
        /// <param></param>
        public static IntIntEvent OnHealthUpdate = new IntIntEvent();

        /// <summary>
        /// Event called when hero's secondary bar is updated 
        /// </summary>
        /// <param></param>
        /// <param></param>
        public static IntIntEvent OnSecondaryUpdate = new IntIntEvent();

        /// <summary>
        /// Event called when the hero moves on the map
        /// </summary>
        /// <param>int : the current level</param>
        /// <param>int : the current xp</param>
        /// <param>int : max xp for the level</param>
        public static IntIntIntEvent OnExperienceUpdate = new IntIntIntEvent();

        /// <summary>
        /// Event for level progression
        /// </summary>
        /// <param></param>
        public static IntIntEvent OnProgressionUpdate = new IntIntEvent();

        /// <summary>
        /// Event when the user needs to display an effect on the HUD
        /// </summary>
        /// <param></param>
        public static HUDEffectEvent HudEffect = new HUDEffectEvent();

        /// <summary>
        /// Event called which count tiles
        /// </summary>
        /// <param></param>
        public static GameObjectEvent TileCount = new GameObjectEvent();

        /// <summary>
        /// Invoke when a game is finished
        /// </summary>
        public static UnityEvent GameStop = new UnityEvent();

        /// <summary>
        /// Invoke when a level is finished
        /// </summary>
        public static UnityEvent LevelStop = new UnityEvent();

        /// <summary>
        /// Event called when the level start
        /// </summary>
        public static UnityEvent LevelStart = new UnityEvent();

        /// <summary>
        /// Event called when the boss start
        /// </summary>
        public static UnityEvent Boss = new UnityEvent();

        /// <summary>
        /// Trigger when the next level is reached
        /// </summary>
        public static UnityEvent NextLevel = new UnityEvent();

        public static UnityEvent GameOver = new UnityEvent();

        public static UnityEvent Victory = new UnityEvent();
        public static IEnumerator VictoryWithDelayCouroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            GlobalEvent.Victory.Invoke();
        }

        /// <summary>
        /// Event called when the hero is loaded
        /// </summary>
        /// <param></param>
        public static HeroTypeEvent LoadHero = new HeroTypeEvent();

        /// <summary>
        /// Event called when the player quit the game
        /// </summary>
        public static UnityEvent QuitGame = new UnityEvent();
    }
}
