using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the UI
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        public Bar HealthBar;
        public Bar SecondaryBar;
        public Bar LevelProgressBar;
        public UIScore UIScore;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public void Awake() {
            GlobalEvent.LevelStart.AddListener(ShowInGameUIElements);
            GlobalEvent.LevelStop.AddListener(ShowEndGameUIElements);
        }

        /// <summary>
        /// This function show the UI element in game.
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        void ShowInGameUIElements() {
            HealthBar.gameObject.SetActive(true);
            SecondaryBar.gameObject.SetActive(true);
            LevelProgressBar.gameObject.SetActive(true);
            UIScore.ShowInGameUIScoreElements();

            Hero hero = GameManager.Instance.GetHero();

            GlobalEvent.OnHealthUpdate.Invoke(hero.CurrentHealth, hero.GetStats().MaxHealth);
            // TODO 
            // GlobalEvent.OnSecondaryUpdate.Invoke();
        }

        /// <summary>
        /// This function show the UI element at end game.
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        void ShowEndGameUIElements(){
            UIScore.ShowEndGameUIScoreElements();
        }
    }
}

