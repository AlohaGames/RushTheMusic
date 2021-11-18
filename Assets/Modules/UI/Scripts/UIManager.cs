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
        public UIInventory UIinventory;
        public UIScore UIScore;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake() {
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
        void ShowInGameUIElements()
        {
            HealthBar.gameObject.SetActive(true);
            SecondaryBar.gameObject.SetActive(true);
            LevelProgressBar.gameObject.SetActive(true);
            UIScore.ShowInGameUIScoreElements();
            UIinventory.gameObject.SetActive(true);

            Hero hero = GameManager.Instance.GetHero();

            GlobalEvent.OnHealthUpdate.Invoke(hero.CurrentHealth, hero.GetStats().MaxHealth);
            if (hero is Warrior)
            {
                Warrior warrior = hero as Warrior;
                GlobalEvent.OnSecondaryUpdate.Invoke(warrior.CurrentRage, warrior.GetStats().MaxRage);
            } else if (hero is Wizard)
            {
                Wizard wizard = hero as Wizard;
                GlobalEvent.OnSecondaryUpdate.Invoke(wizard.CurrentMana, wizard.GetStats().MaxMana);
            }

            GlobalEvent.OnProgressionUpdate.Invoke(0, LevelManager.Instance.LevelMapping.TileCount);
            // declaration of some items in the inventory
            Inventory.Instance.AddItem(new HealPotion(20));
            Inventory.Instance.AddItem(new HealPotion(20));
            Inventory.Instance.AddItem(new HealPotion(20));


        }

        /// <summary>
        /// This function show the UI element at end game.
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
