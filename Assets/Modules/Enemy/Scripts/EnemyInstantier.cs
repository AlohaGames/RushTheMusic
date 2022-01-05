using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the enemy instantiation
    /// </summary>
    public class EnemyInstantier : Singleton<EnemyInstantier>
    {
        [SerializeField]
        private List<GameObject> enemyPrefabs = new List<GameObject>();

        /// <summary>
        /// This function instantiate an enemy with an ID
        /// </summary>
        /// <param name="id">The ID of enemy to instantiate</param>
        /// <returns>
        /// A GameObject instance of enemy prefab
        /// </returns>
        GameObject InstantiateEnemy(int id)
        {
            GameObject instance = Instantiate(enemyPrefabs[id]);
            Entity enemy = instance.GetComponent<Entity>();
            enemy.Init();
            return instance;
        }

        /// <summary>
        /// This function instantiate an enemy with an enemy type.
        /// <example> Example(s):
        /// <code>
        /// EnnemyInstancier.Instance.InstantiateEnemy(EnemyType.Wizard);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="type"></param>
        /// <returns>
        /// Instantiated ennemy
        /// </returns>
        public GameObject InstantiateEnemy(EnemyType type)
        {
            return InstantiateEnemy((int) type);
        }
    }

    /// <summary>
    /// Enumerate the list of enemies listed in EnemyManager
    /// </summary>
    public enum EnemyType
    {
        /// <summary>
        /// Generic type (Never used in game)
        /// </summary>
        generic = 0,

        /// <summary>
        /// Lancer Enemy
        /// </summary>
        lancer = 1,

        /// <summary>
        /// Assassin Enemy
        /// </summary>
        assassin = 2,

        /// <summary>
        /// Wyrmling Enemy (flying)
        /// </summary>
        wyrmling = 3,

        /// <summary>
        /// Wall
        /// </summary>
        wall = 4,

        /// <summary>
        /// Chest
        /// </summary>
        chest = 5,

        /// <summary>
        /// FireLancer
        /// </summary>
        fireLancer = 6,

        /// <summary>
        /// IceLancer
        /// </summary>
        iceLancer = 7,

        /// Fire Wyrmling (flying)
        /// </summary>
        fireWyrmling = 8,

        /// <summary>
        /// Ice Wyrmling (flying)
        /// </summary>
        iceWyrmling = 9,
    }
}
