using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class UIManager : Singleton<UIManager>
    {
        public Bar HealthBar;
        public Bar SecondaryBar;
        public Bar LevelProgressBar;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void Awake()
        {
            GlobalEvent.LevelStart.AddListener(ShowUIElements);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        void ShowUIElements()
        {
            HealthBar.gameObject.SetActive(true);
            SecondaryBar.gameObject.SetActive(true);
            LevelProgressBar.gameObject.SetActive(true);

            Hero hero = GameManager.Instance.GetHero();

            GlobalEvent.OnHealthUpdate.Invoke(hero.CurrentHealth, hero.GetStats().MaxHealth);
            // TODO 
            // GlobalEvent.OnSecondaryUpdate.Invoke();
        }
    }
}

