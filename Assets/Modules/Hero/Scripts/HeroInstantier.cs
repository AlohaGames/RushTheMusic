using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heros
{
    public class HeroInstantier : Singleton<HeroInstantier>
    {
        [SerializeField] private List<GameObject> HeroPrefabs;

        public GameObject InstantiateHero(int id, int hp, int attackAmount)
        {
            GameObject instance = Instantiate(HeroPrefabs[id]);
            instance.GetComponent<Hero>().Init(hp, attackAmount);
            return instance;
        }

        public GameObject InstantiateHero(HeroType type, int hp, int attackAmount)
        {
            return InstantiateHero((int) type, hp, attackAmount);
        }
    }
    public enum HeroType
    {
        generic = 0
    }
}


