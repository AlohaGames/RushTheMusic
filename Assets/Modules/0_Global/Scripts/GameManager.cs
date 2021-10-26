using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class GameManager : Singleton<GameManager>
    {
        private bool isGamePaused = false;
        private bool isPlaying = false;
        private Hero hero;

        [SerializeField]
        private string defaultLevel;

        #region Events
        public void LoadLevel(string level, bool isTuto = false)
        {
            GlobalEvent.LoadLevel.Invoke(level, isTuto);
        }

        public void LoadLevel()
        {
            LoadLevel(defaultLevel);
        }

        public void StartLevel()
        {
            isPlaying = true;
            GlobalEvent.LevelStart.Invoke();
        }

        public void StopLevel()
        {
            isPlaying = false;
            GlobalEvent.LevelStop.Invoke();
        }

        public void LoadHero(HeroType type)
        {
            GlobalEvent.LoadHero.Invoke(type);
        }

        public void ResumeGame()
        {
            isGamePaused = false;
            GlobalEvent.Resume.Invoke();
        }

        public void PauseGame()
        {
            isGamePaused = true;
            GlobalEvent.Pause.Invoke();
        }

        public void Quit()
        {
            GlobalEvent.QuitGame.Invoke();
        }

        #endregion

        public void SetHero(Hero hero)
        {
            if (this.hero != null)
            {
                Destroy(this.hero.gameObject);
            }
            this.hero = hero;
        }

        public Hero GetHero()
        {
            return hero;
        }

        #region KeyEvents

        public void Update()
        {
            if (Input.GetKeyDown(InputBinding.Instance.pause))
            {
                if (isPlaying)
                {
                    if (isGamePaused)
                        ResumeGame();
                    else
                        PauseGame();
                }
            }
            if (Input.GetKeyDown(InputBinding.Instance.quit))
            {
                Quit();
            }
            if (Input.GetKeyDown(InputBinding.Instance.attack))
            {
                // hero.Attack();
            }
            if (Input.GetKeyDown(InputBinding.Instance.defense))
            {
                // Defense
            }
        }
        #endregion
        /*
                public KeyCode pause = KeyCode.Escape;
            public KeyCode quit = KeyCode.F12;
            public KeyCode attack = KeyCode.Mouse0;
            public KeyCode defense = KeyCode.Mouse1;*/
    }
}
