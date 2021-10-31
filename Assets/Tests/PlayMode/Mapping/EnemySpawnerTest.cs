using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class EnemySpawnerTest
    {
        [UnityTest]
        public IEnumerator EnemySpawnerCountTileTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            EnemySpawner enemySpawner = EnemySpawner.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.LevelMapping = new LevelMapping();
            yield return null;

            tilesManager.StartGame();
            yield return null;

            Assert.AreEqual(19, enemySpawner.TilesCounter);

            tilesManager.StopGame();
            yield return null;

            GameObject.Destroy(manager);
            yield return null;
        }

        [UnityTest]
        public IEnumerator EnemySpawnerRestCountTileTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            EnemySpawner enemySpawner = EnemySpawner.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.LevelMapping = new LevelMapping();
            yield return null;

            tilesManager.StartGame();
            yield return null;

            Assert.AreNotEqual(0, enemySpawner.TilesCounter);
            yield return null;

            tilesManager.StopGame();
            yield return null;

            Assert.AreEqual(0, enemySpawner.TilesCounter);
            GameObject.Destroy(manager);
            yield return null;
        }
    }
}
