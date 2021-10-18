using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha.Hero
{
    public class HeroInstantier : Singleton<HeroInstantier>
    {
        [SerializeField] private List<GameObject> HeroPrefabs;

        private void Awake()
        {
            GlobalEvent.LoadHero.AddListener((heroType) => {
                InstantiateHero(heroType);
            });
        }

        public GameObject InstantiateHero(HeroType type)
        {
            return InstantiateHero((int)type);
        }

        private GameObject InstantiateHero(int id)
        {
            GameObject instance = Instantiate(HeroPrefabs[id]);
            return instance;
        }


    }
    public enum HeroType
    {
        Generic = 0,
        Warrior = 1
    }
}


