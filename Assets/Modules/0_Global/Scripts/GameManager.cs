using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha {
    public class GameManager : Singleton<GameManager>
    {
        private Hero hero;

        [SerializeField]
        private string defaultLevel;
        public void LoadLevel(string level, bool isTuto = false){
            GlobalEvent.LoadLevel.Invoke(level, isTuto);
        }

        public void LoadLevel() {
            LoadLevel(defaultLevel);
        }

        public void StartLevel(){
            GlobalEvent.LevelStart.Invoke();
        }

        public void LoadHero(HeroType type) {
            GlobalEvent.LoadHero.Invoke(type);
        }

        public void ResumeGame() {
            GlobalEvent.Resume.Invoke();
        }

        public void PauseGame() {
            GlobalEvent.Pause.Invoke();
        }

        public void SetHero(Hero hero){
            if(this.hero != null) {
                Destroy(this.hero.gameObject);
            }
            this.hero = hero;
            Debug.Log(hero);
        }

        public Hero GetHero() {
            return hero;
        }
    }
}
