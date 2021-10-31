using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        public int tilesCounter = 0;

        public void Awake()
        {
            Debug.Log("Start listening to tiles creation");
            GlobalEvent.TileCount.AddListener(CountTile);
            GlobalEvent.LevelStop.AddListener(ResetCount);
        }

        public void ResetCount()
        {
            tilesCounter = 0;
            Debug.Log($"Reset tiles count to {tilesCounter}");
        }

        public void CountTile(GameObject tile)
        {
            tilesCounter++;
            List<EnemyMapping> enemiesMapping = LevelManager.Instance.levelMapping.getEnnemies(tilesCounter);
            int enemyNumber = enemiesMapping.Count;
            if (enemyNumber > 0)
            {
                Debug.Log($"{enemyNumber} enemiesMapping found on tile {tilesCounter}");
                foreach (EnemyMapping enemyMapping in enemiesMapping)
                {
                    GameObject enemy = EnemyInstantier.Instance.InstantiateEnemy(enemyMapping.enemyType);
                    enemy.transform.position = enemyMapping.GetPosition(tile.transform.position.z);
                    enemy.transform.SetParent(tile.transform);
                }
            }
        }

        public void OnDestroy()
        {
            GlobalEvent.TileCount.RemoveListener(CountTile);
            GlobalEvent.LevelStop.RemoveListener(ResetCount);
        }
    }
}
