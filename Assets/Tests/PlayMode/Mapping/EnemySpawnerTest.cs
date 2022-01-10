using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// This class test the enemy spawner class functions.
    /// </summary>
    public class EnemySpawnerTest
    {
        /// <summary>
        /// Check if tiles manager instance the right number of tiles
        /// </summary>
        [UnityTest]
        public IEnumerator EnemySpawnerCountTileTest()
        {
            // Instance managers
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            EnemySpawner enemySpawner = EnemySpawner.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.LevelMapping = new LevelMapping();
            yield return null;

            tilesManager.OnLevelStart();
            yield return null;

            // Check if 19 tiles spawn
            Assert.AreEqual(19, enemySpawner.TilesCounter);

            tilesManager.Reset();
            yield return null;

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Check if tiles counter successfully reset
        /// </summary>
        [UnityTest]
        public IEnumerator EnemySpawnerResetCountTileTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            TilesManager tilesManager = TilesManager.Instance;
            EnemySpawner enemySpawner = EnemySpawner.Instance;
            LevelManager levelManager = LevelManager.Instance;
            levelManager.LevelMapping = new LevelMapping();
            yield return null;

            tilesManager.OnLevelStart();
            yield return null;

            // Check if tiles counter successfully reset
            Assert.AreNotEqual(0, enemySpawner.TilesCounter);
            yield return null;

            enemySpawner.Reset();
            yield return null;

            // Check if tiles counter successfully reset
            Assert.AreEqual(0, enemySpawner.TilesCounter);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
