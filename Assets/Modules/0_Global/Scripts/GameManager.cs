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
        private bool isGameFinished = false;
        private bool isGamePaused = false;
        public bool IsPlaying = false;
        public bool IsInfinite = false;

        private Hero hero;
        public RtmConfig Config = new RtmConfig();

        void Awake()
        {
            GlobalEvent.GameOver.AddListener(FinishGame);
            GlobalEvent.Victory.AddListener(FinishLevel);
            GlobalEvent.Resume.AddListener(UnFreeze);
            GlobalEvent.Pause.AddListener(Freeze);
        }

        /// <summary>
        /// Will start the loaded level.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.StartLevel();
        /// </code>
        /// </example>
        /// </summary>
        public void StartLevel()
        {
            UnFreeze();
            IsPlaying = true;
            isGamePaused = false;
            isGameFinished = false;
            GlobalEvent.LevelStart.Invoke();
        }

        /// <summary>
        /// Stop the game.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.FinishGame();
        /// </code>
        /// </example>
        /// </summary>
        public void FinishGame()
        {
            FinishLevel();
            GlobalEvent.GameStop.Invoke();
            IsPlaying = false;
            IsInfinite = false;
            ContainerManager.Instance.ClearContainer(ContainerTypes.Item);
            if (hero != null)
            {
                GameObject.Destroy(hero.gameObject);
            }
        }

        /// <summary>
        /// Will stop the current level.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.FinishLevel();
        /// </code>
        /// </example>
        /// </summary>
        public void FinishLevel()
        {
            Freeze();
            isGameFinished = true;
            ContainerManager.Instance.ClearContainers(
                new[] { ContainerTypes.Enemy, ContainerTypes.Projectile, ContainerTypes.Text }
            );
            GlobalEvent.LevelStop.Invoke();
        }

        /// <summary>
        /// Will ask to load a specific Hero based on <paramref name="type"/>.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.LoadHero(Warrior);
        ///     GameManager.Instance.LoadHero(Wizard);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="type">The Hero Type</param>
        public void LoadHero(HeroType type)
        {
            GlobalEvent.LoadHero.Invoke(type);
        }

        /// <summary>
        /// Will return if the game is paused or not
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.IsGamePaused()
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// a boolean if the game is paused or not
        /// </returns>
        public bool IsGamePaused()
        {
            return this.isGamePaused;
        }

        /// <summary>
        /// Will return if the game is finished or not
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.IsGameFinished()
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// a boolean if the game is finished or not
        /// </returns>
        public bool IsGameFinished()
        {
            return this.isGameFinished;
        }

        /// <summary>
        /// Will set if leap mode is activated in the game
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.SetLeapMode()
        /// </code>
        /// </example>
        /// </summary>
        /// <param bool="leapMode">The new value of LeapMode</param>
        public void SetLeapMode(bool leapMode)
        {
            this.Config.LeapMode = leapMode;
        }

        /// <summary>
        /// Will ask to Resume a paused Game (do nothing if already resumed)
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.ResumeGame()
        /// </code>
        /// </example>
        /// </summary>
        public void ResumeGame()
        {
            isGamePaused = false;
            GlobalEvent.Resume.Invoke();
        }

        /// <summary>
        /// Will ask to Pause the game (do nothing if already paused).
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.PauseGame();
        /// </code>
        /// </example>
        /// </summary>
        public void PauseGame()
        {
            isGamePaused = true;
            GlobalEvent.Pause.Invoke();
        }

        /// <summary>
        /// Will ask to Quit the game.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.Quit();
        /// </code>
        /// </example>
        /// </summary>
        public void Quit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Set the new current Hero and Destroy the old Hero if needed.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.SetHero(wizard)
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="hero">The new current Hero</param>
        public void SetHero(Hero hero)
        {
            if (this.hero != null)
            {
                GameObject.Destroy(hero.gameObject);
            }
            this.hero = hero;
        }

        /// <summary>
        /// Return the current playing Hero.
        /// <example> Example(s):
        /// <code>
        ///     GameManager.Instance.GetHero()
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// The current Hero
        /// </returns>
        public Hero GetHero()
        {
            return hero;
        }

        #region KeyEvents
        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled. Called other method based on Key Input.
        /// </summary>
        void Update()
        {
            if (Input.GetKeyDown(InputBinding.Instance.Pause))
            {
                if (IsPlaying && !isGameFinished)
                {
                    if (isGamePaused)
                        ResumeGame();
                    else
                        PauseGame();
                }
            }
            if (Input.GetKeyDown(InputBinding.Instance.Quit))
            {
                Quit();
            }
        }
        #endregion

        public void Freeze()
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
        }

        public void UnFreeze()
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
        }

        void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(FinishGame);
            GlobalEvent.Victory.RemoveListener(FinishLevel);
            GlobalEvent.Resume.RemoveListener(UnFreeze);
            GlobalEvent.Pause.RemoveListener(Freeze);
        }
    }
}
