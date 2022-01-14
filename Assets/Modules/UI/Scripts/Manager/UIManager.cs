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
        public Bar ExpBar;
        public Bar LevelProgressBar;
        public UIInventory UIInventory;
        public UIScore UIScore;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.LevelStart.AddListener(ShowInGameUIElements);
            GlobalEvent.Victory.AddListener(ShowEndGameUIElements);
        }

        /// <summary>
        /// This function show the UI element in game.
        /// <example> Example(s):
        /// <code>
        ///     ShowInGameUIElements()
        /// </code>
        /// </example>
        /// </summary>
        void ShowInGameUIElements()
        {
            HealthBar.gameObject.SetActive(true);
            SecondaryBar.gameObject.SetActive(true);
            ExpBar.gameObject.SetActive(true);
            LevelProgressBar.gameObject.SetActive(true);
            UIScore.ShowInGameUIScoreElements();
            UIInventory.ShowInGameInventory();

            Hero hero = GameManager.Instance.GetHero();

            GlobalEvent.OnHealthUpdate.Invoke(hero.CurrentHealth, hero.GetStats().MaxHealth);
            if (hero is Warrior)
            {
                Warrior warrior = hero as Warrior;
                GlobalEvent.OnSecondaryUpdate.Invoke(warrior.CurrentRage, warrior.GetStats().MaxRage);
            }
            else if (hero is Wizard)
            {
                Wizard wizard = hero as Wizard;
                GlobalEvent.OnSecondaryUpdate.Invoke(wizard.CurrentMana, wizard.GetStats().MaxMana);
            }
            GlobalEvent.OnExperienceUpdate.Invoke(hero.GetStats().Level, hero.GetStats().XP, hero.GetStats().MaxXP);
            GlobalEvent.OnProgressionUpdate.Invoke(0, LevelManager.Instance.LevelMapping.TileCount);
        }

        /// <summary>
        /// This function show the UI element at end game.
        /// <example> Example(s):
        /// <code>
        ///     ShowEndGameUIElements()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowEndGameUIElements()
        {
            GameManager.Instance.Freeze();
            UIScore.ShowEndGameUIScoreElements();
        }

        /// <summary>
        /// Hide EndGame screen
        /// </summary>
        public void HideEndGameUIElements()
        {
            GameManager.Instance.UnFreeze();
            UIScore.HideEndGameUIScoreElements();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.LevelStart.RemoveListener(ShowInGameUIElements);
            GlobalEvent.Victory.RemoveListener(ShowEndGameUIElements);
        }
    }
}
