using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class HeroInstantier : Singleton<HeroInstantier>
    {
        [SerializeField]
        private List<GameObject> HeroPrefabs = new List<GameObject>();

        private void Awake()
        {
            GlobalEvent.LoadHero.AddListener(InstantiateHero);
        }

        public void InstantiateHero(HeroType type)
        {
            GameManager.Instance.SetHero(InstantiateHeroID((int)type));
        }

        private Hero InstantiateHeroID(int id)
        {
            Hero instance = (Hero) Instantiate(HeroPrefabs[id]).GetComponent<Entity>();
            instance.Init();
            return instance;
        }

        public void OnDestroy() {
            GlobalEvent.LoadHero.RemoveListener(InstantiateHero);
        }


    }
    public enum HeroType
    {
        Generic = 0,
        Warrior = 1,
        Wizard = 2
    }
}


