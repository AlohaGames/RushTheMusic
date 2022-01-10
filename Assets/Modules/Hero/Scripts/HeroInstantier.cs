using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public enum HeroType
    {
        Generic = 0,
        Warrior = 1,
        Wizard = 2
    }

    /// <summary>
    /// Singleton that manage the hero instantiation
    /// </summary>
    public class HeroInstantier : Singleton<HeroInstantier>
    {
        [SerializeField]
        private List<GameObject> heroPrefabs = new List<GameObject>();

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
       void Awake()
        {
            GlobalEvent.LoadHero.AddListener(InstantiateHero);
        }

        /// <summary>
        /// Instantiate a Hero on the map
        /// <example> Example(s):
        /// <code>
        ///     HeroInstantier.InstantiateHero(HeroType.Warrior());
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="type"></param>
        public void InstantiateHero(HeroType type)
        {
            GameManager.Instance.SetHero(InstantiateHeroID((int)type));
        }

        /// <summary>
        /// Instantiate a Hero on the map with its ID
        /// <example> Example(s):
        /// <code>
        /// HeroInstantier.InstantiateHero(1);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Instance of the hero
        /// </returns>
        private Hero InstantiateHeroID(int id)
        {
            Hero instance = (Hero)Instantiate(heroPrefabs[id]).GetComponent<Entity>();
            instance.Init();
            return instance;
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.LoadHero.RemoveListener(InstantiateHero);
        }
    }
}
