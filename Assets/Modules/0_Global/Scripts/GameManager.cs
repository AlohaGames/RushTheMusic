using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage globaly the game
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        private bool isGamePaused = false;
        private bool isPlaying = false;
        private Hero hero;

        [SerializeField]
        private string defaultLevel;

        #region Events
        /// <summary>
        /// Will ask to load the request <paramref name="level"/>
        /// <example> Examples:
        /// <code>
        ///     LoadLevel(monlevel);
        /// </code>
        /// <code>
        ///     LoadLevel(monautrelevel, true);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="level">Level Name with .rtm extension</param>
        /// <param name="isTuto">Is the level a tutorial (locate in StreamingAssets)</param>
        public void LoadLevel(string level, bool isTuto = false)
        {
            GlobalEvent.LoadLevel.Invoke(level, isTuto);
        }

        /// <summary>
        /// Will ask to load the default level
        /// </summary>
        public void LoadLevel()
        {
            LoadLevel(defaultLevel);
        }

        /// <summary>
        /// Will start the loaded level
        /// </summary>
        public void StartLevel()
        {
            isPlaying = true;
            GlobalEvent.LevelStart.Invoke();
        }

        /// <summary>
        /// Will stop the current level
        /// </summary>
        public void StopLevel()
        {
            isPlaying = false;
            GlobalEvent.LevelStop.Invoke();
        }

        /// <summary>
        /// Will ask to load a specific Hero based on <paramref name="type"/>
        /// </summary>
        /// <param name="type">The Hero Type</param>
        public void LoadHero(HeroType type)
        {
            GlobalEvent.LoadHero.Invoke(type);
        }

        /// <summary>
        /// Will ask to Resume a paused Game (do nothing if already resumed)
        /// </summary>
        public void ResumeGame()
        {
            isGamePaused = false;
            GlobalEvent.Resume.Invoke();
        }

        /// <summary>
        /// Will ask to Pause the game (do nothing if already paused)
        /// </summary>
        public void PauseGame()
        {
            isGamePaused = true;
            GlobalEvent.Pause.Invoke();
        }

        /// <summary>
        /// Will ask to Quit the game
        /// </summary>
        public void Quit()
        {
            GlobalEvent.QuitGame.Invoke();
        }

        #endregion

        /// <summary>
        /// Set the new current Hero and Destroy the old Hero if needed
        /// </summary>
        /// <param name="hero">The new current Hero</param>
        public void SetHero(Hero hero)
        {
            if (this.hero != null)
            {
                Destroy(this.hero.gameObject);
            }
            this.hero = hero;
        }

        /// <summary>
        /// Return the current playing Hero
        /// </summary>
        /// <returns>The current Hero</returns>
        public Hero GetHero()
        {
            return hero;
        }

        #region KeyEvents

        /// <summary>
        /// Called each Update, called other method based on Key Input
        /// </summary>
        public void Update()
        {
            if (Input.GetKeyDown(InputBinding.Instance.pause))
            {
                if (isPlaying)
                {
                    if (isGamePaused)
                        ResumeGame();
                    else
                        PauseGame();
                }
            }
            if (Input.GetKeyDown(InputBinding.Instance.quit))
            {
                Quit();
            }
            if (Input.GetKeyDown(InputBinding.Instance.attack))
            {
                // hero.Attack();
            }
            if (Input.GetKeyDown(InputBinding.Instance.defense))
            {
                // Defense
            }
        }
        #endregion
    }
}
