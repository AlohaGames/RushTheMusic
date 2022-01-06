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
        private int heroLevel = -1;
        public int TilesCounter = 0;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            Debug.Log("Start listening to tiles creation");
            GlobalEvent.TileCount.AddListener(CountTile);
            GlobalEvent.LevelStop.AddListener(ResetCount);
            GlobalEvent.NextLevel.AddListener(NextLevelReached);
        }

        public void NextLevelReached()
        {
            // On each next level, check current level hero
            this.saveLevelHero();
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
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
        /// TODO
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

                    // If we don't know the level of the hero, check for it
                    if (heroLevel == -1)
                    {
                        this.saveLevelHero();
                    }

                    // Stats scale based on hero level and current map number
                    // TODO-TRISTAN: Scale stats based on this.heroLevel
                    entity.Init(stats);

                    enemy.transform.position = enemyMapping.GetPosition(tile.transform.position.z);
                }
            }
        }

        private void saveLevelHero()
        {
            // Save the new hero
            // It will be use later to instanciate ennemy stats
            Hero hero = GameManager.Instance.GetHero();
            this.heroLevel = hero.GetStats().Level;
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
            GlobalEvent.LevelStop.RemoveListener(ResetCount);
            GlobalEvent.NextLevel.RemoveListener(NextLevelReached);
        }
    }
}
