using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class HeroInstantier : Singleton<HeroInstantier>
    {
        [SerializeField] private List<GameObject> HeroPrefabs;

        public GameObject InstantiateHero(int id)
        {
            GameObject instance = Instantiate(HeroPrefabs[id]);
            return instance;
        }

        public GameObject InstantiateHero(HeroType type)
        {
            return InstantiateHero((int)type);
        }
    }
    public enum HeroType
    {
        generic = 0,
        guerrier = 1
    }
}


