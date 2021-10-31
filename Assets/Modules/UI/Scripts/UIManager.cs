using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        public Bar HealthBar;
        public Bar SecondaryBar;
        public Bar LevelProgressBar;
        public UIScore UIScore;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void Awake() {
            GlobalEvent.LevelStart.AddListener(ShowInGameUIElements);
            GlobalEvent.LevelStop.AddListener(ShowEndGameUIElements);
        }

        /// <summary>
        /// TODO
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void ShowEndGameUIElements(){
            UIScore.ShowEndGameUIScoreElements();
        }
    }
}

