using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;
using Aloha.Hero;

namespace Aloha {
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private string defaultLevel;
        public void LoadLevel(string level){
            GlobalEvent.LoadLevel.Invoke(level);
        }

        public void LoadLevel() {
            LoadLevel(defaultLevel);
        }

        public void StartLevel(){
            GlobalEvent.LevelStart.Invoke();
        }

        public void LoadHero(HeroType type) {
            HeroInstantier.Instance.InstantiateHero(type);
        }

        public void LoadGeneric(){
            LoadHero(HeroType.Generic);
        }
    }
}
