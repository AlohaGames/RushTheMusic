using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="type"></param>
        public void InstantiateHero(HeroType type)
        {
            GameManager.Instance.SetHero(InstantiateHeroID((int)type));
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// TODO
        /// </returns>
        private Hero InstantiateHeroID(int id)
        {
            Hero instance = (Hero)Instantiate(heroPrefabs[id]).GetComponent<Entity>();
            instance.Init();
            return instance;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.LoadHero.RemoveListener(InstantiateHero);
        }
    }
    public enum HeroType
    {
        Generic = 0,
        Warrior = 1
    }
}
