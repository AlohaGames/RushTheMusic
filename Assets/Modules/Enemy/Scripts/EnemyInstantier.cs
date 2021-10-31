using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class EnemyInstantier : Singleton<EnemyInstantier>
    {
        [SerializeField] 
        private List<GameObject> enemyPrefabs;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public GameObject InstantiateEnemy(int id)
        {
            GameObject instance = Instantiate(enemyPrefabs[id]);
            Enemy enemy = instance.GetComponent<Enemy>();
            enemy.Init();
            return instance;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
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
