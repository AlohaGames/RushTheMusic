using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

//TODO: explain your F***** TEST (like @Youen in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// This class test the enemy spawner class functions.
    /// </summary>
    public class EnemySpawnerTest
    {
        /// <summary>
        /// TODO @Tristan? (Not sure)
        /// </summary>
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

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// TODO
        /// </summary>
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

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
