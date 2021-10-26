using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Aloha.Test
{
    public class EnemySpawnerTest
    {
        [UnityTest]
        public IEnumerator EnemySpawnerCountTileTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            TilesManager tilesManager = TilesManager.Instance;
            EnemySpawner enemySpawner = EnemySpawner.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.levelMapping = new LevelMapping();
            yield return null;

            tilesManager.StartGame();
            yield return null;

            Assert.AreEqual(19, enemySpawner.tilesCounter);

            tilesManager.StopGame();
            yield return null;

            GameObject.Destroy(manager);
            yield return null;
        }

          [UnityTest]
        public IEnumerator EnemySpawnerRestCountTileTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            TilesManager tilesManager = TilesManager.Instance;
            EnemySpawner enemySpawner = EnemySpawner.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.levelMapping = new LevelMapping();
            yield return null;

            tilesManager.StartGame();
            yield return null;

            Assert.AreNotEqual(0, enemySpawner.tilesCounter);
            yield return null;

            tilesManager.StopGame();
            yield return null;

            Assert.AreEqual(0, enemySpawner.tilesCounter);
            GameObject.Destroy(manager);
            yield return null;
        }
    }
}
