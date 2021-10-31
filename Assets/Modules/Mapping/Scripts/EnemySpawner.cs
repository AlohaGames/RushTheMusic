using UnityEngine;
using Aloha;
using Aloha.Events;
using System.Collections.Generic;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        public int TilesCounter = 0;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void Awake()
        {
            Debug.Log("Start listening to tiles creation");
            GlobalEvent.TileCount.AddListener(CountTile);
            GlobalEvent.LevelStop.AddListener(ResetCount);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void ResetCount()
        {
            TilesCounter = 0;
            Debug.Log($"Reset tiles count to {TilesCounter}");
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="tile"></param>
        public void CountTile(GameObject tile)
        {
            TilesCounter++;
            List<EnemyMapping> enemiesMapping = LevelManager.Instance.LevelMapping.GetEnnemies(TilesCounter);
            int enemyNumber = enemiesMapping.Count;
            if (enemyNumber > 0)
            {
                Debug.Log($"{enemyNumber} enemiesMapping found on tile {TilesCounter}");
                foreach (EnemyMapping enemyMapping in enemiesMapping)
                {
                    GameObject enemy = EnemyInstantier.Instance.InstantiateEnemy(enemyMapping.enemyType);
                    enemy.transform.position = enemyMapping.GetPosition(tile.transform.position.z);
                    enemy.transform.SetParent(tile.transform);
                }
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
            GlobalEvent.LevelStop.RemoveListener(ResetCount);
        }
    }
}
