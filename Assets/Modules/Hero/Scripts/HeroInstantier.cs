using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.Hero
{
    public class HeroInstantier : Singleton<HeroInstantier>
    {
        [SerializeField] private List<GameObject> HeroPrefabs;

        private void Awake()
        {
            HeroInvokerButton.onInvokeEvent.AddListener((heroType) => {
                InstantiateHero(heroType);
                Debug.Log("J'ai fait un truc");
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


