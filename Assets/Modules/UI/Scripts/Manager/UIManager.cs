using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha;
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
        public HUDEffect HUDEffect;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.LevelStart.AddListener(ShowInGameUIElements);
        }

        public void HideForBoss()
        {
            LevelProgressBar.gameObject.SetActive(false);
            ExpBar.gameObject.SetActive(false);
            UIScore.Hide();
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
            HUDEffect.gameObject.SetActive(false);
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
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.LevelStart.RemoveListener(ShowInGameUIElements);
        }
    }
}
