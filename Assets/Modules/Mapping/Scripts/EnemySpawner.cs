using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the enemy spawner
    /// </summary>
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        public int TilesCounter = 0;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            Debug.Log("Start listening to tiles creation");
            GlobalEvent.TileCount.AddListener(CountTile);
            GlobalEvent.LevelStop.AddListener(ResetCount);
        }

        /// <summary>
        /// Reset tiles counter to 0
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.LevelStop.AddListener(ResetCount);
        /// </code>
        /// </example>
        /// </summary>
        public void ResetCount()
        {
            TilesCounter = 0;
            Debug.Log($"Reset tiles count to {TilesCounter}");
        }

        /// <summary>
        /// Count a new tile when event is called
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.TileCount.AddListener(CountTile);
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
                    GameObject enemy = EnemyInstantier.Instance.InstantiateEnemy(enemyMapping.EnemyType);

                    // Define enemy stats from mapping
                    Entity entity = enemy.GetComponent<Entity>();
                    EnemyStats stats = Instantiate(entity.GetStats() as EnemyStats);
                    stats.Attack = enemyMapping.Stats.Attack;
                    stats.Defense = enemyMapping.Stats.Defense;
                    stats.Level = enemyMapping.Stats.Level;
                    stats.MaxHealth = enemyMapping.Stats.MaxHealth;
                    entity.CurrentHealth = enemyMapping.Stats.MaxHealth;
                    entity.Init(stats);

                    enemy.transform.position = enemyMapping.GetPosition(tile.transform.position.z);
                    // enemy.transform.SetParent(tile.transform);
                }
            }
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
            GlobalEvent.LevelStop.RemoveListener(ResetCount);
        }
    }
}
