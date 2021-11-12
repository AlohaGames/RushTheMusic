using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    public class UIManager : Singleton<UIManager>
    {
        public Bar HealthBar;
        public Bar SecondaryBar;
        public Bar LevelProgressBar;
        public UIInventory UIinventory;
        public UIScore UIScore;

        public void Awake() {
            GlobalEvent.LevelStart.AddListener(ShowInGameUIElements);
            GlobalEvent.LevelStop.AddListener(ShowEndGameUIElements);
        }

        void ShowInGameUIElements()
        {
            HealthBar.gameObject.SetActive(true);
            SecondaryBar.gameObject.SetActive(true);
            LevelProgressBar.gameObject.SetActive(true);
            UIScore.ShowInGameUIScoreElements();
            UIinventory.gameObject.SetActive(true);

            Hero hero = GameManager.Instance.GetHero();

            GlobalEvent.OnHealthUpdate.Invoke(hero.currentHealth, hero.GetStats().maxHealth);
            if (hero is Warrior)
            {
                Warrior warrior = hero as Warrior;
                GlobalEvent.OnSecondaryUpdate.Invoke(warrior.currentRage, warrior.GetStats().maxRage);
            } else if (hero is Wizard)
            {
                Wizard wizard = hero as Wizard;
                GlobalEvent.OnSecondaryUpdate.Invoke(wizard.CurrentMana, wizard.GetStats().MaxMana);
            }
            GlobalEvent.OnProgressionUpdate.Invoke(0, LevelManager.Instance.levelMapping.tileCount);

            // declaration of some items in the inventory
            Inventory.Instance.AddItem(new HealPotion(20));
            Inventory.Instance.AddItem(new HealPotion(20));
            Inventory.Instance.AddItem(new HealPotion(20));
        }

        public void ShowEndGameUIElements(){
            UIScore.ShowEndGameUIScoreElements();
        }
    }
}

