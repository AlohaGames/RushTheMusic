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
        public Text InGameScoreText;
        public Text TotalScoreText;

        public void Awake() {
            GlobalEvent.LevelStart.AddListener(ShowInGameUIElements);
            GlobalEvent.LevelStop.AddListener(ShowEndGameUIElements);
        }

        void ShowInGameUIElements() {
            HealthBar.gameObject.SetActive(true);
            SecondaryBar.gameObject.SetActive(true);
            LevelProgressBar.gameObject.SetActive(true);
            InGameScoreText.gameObject.SetActive(true);

            Hero hero = GameManager.Instance.GetHero();

            GlobalEvent.OnHealthUpdate.Invoke(hero.currentHealth, hero.GetStats().maxHealth);
            // TODO 
            // GlobalEvent.OnSecondaryUpdate.Invoke();
        }

        public void ShowEndGameUIElements(){
            TotalScoreText.text = "Score total: " + ScoreManager.Instance.TotalScore;
        }
    }
}

