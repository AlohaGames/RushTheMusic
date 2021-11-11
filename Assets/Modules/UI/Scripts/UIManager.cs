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
        }

        public void ShowEndGameUIElements(){
            UIScore.ShowEndGameUIScoreElements();
        }
    }
}

