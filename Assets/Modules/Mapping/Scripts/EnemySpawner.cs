using UnityEngine;
using Aloha;
using Aloha.Events;
using System.Collections.Generic;

namespace Aloha.Example
{
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        int tilesCounter = 0;


        public void Start()
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
                    Debug.Log(enemy.transform.position);
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