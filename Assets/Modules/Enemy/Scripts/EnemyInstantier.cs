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
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="id">The ID of enemy to instantiate</param>
        /// <returns>
        /// A GameObject instance of enemy prefab
        /// </returns>
        public GameObject InstantiateEnemy(int id)
        {
            GameObject instance = Instantiate(enemyPrefabs[id]);
            Enemy enemy = instance.GetComponent<Enemy>();
            enemy.Init();
            return instance;
        }

        /// <summary>
        /// This function instantiate an enemy with an enemy type.
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="type"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public GameObject InstantiateEnemy(EnemyType type)
        {
            return InstantiateEnemy((int) type);
        }


    }
    public enum EnemyType
    {
        generic = 0
    }
}
