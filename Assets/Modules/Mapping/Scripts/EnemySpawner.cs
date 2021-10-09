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

            // TODO: Should be loaded via button !!!
            LevelManager.Instance.Load();
        }

        public void ResetCount()
        {
            tilesCounter = 0;
            Debug.Log($"Reset tiles count to {tilesCounter}");
        }
        public void CountTile()
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
                    Debug.Log(enemy.transform.position);
                    enemy.transform.position = new Vector3(0, 1, 10);
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
