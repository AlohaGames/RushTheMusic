using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    /// <summary>
    /// Test the wall's fonctions
    /// </summary>
    public class WallTest
    {
        /// <summary>
        /// Check if a wall was bumped
        /// </summary>
        [UnityTest]
        public IEnumerator WallGetBumpTest()
        {
            // Instance wall
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Wall wall = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.wall).GetComponent<Wall>();
            TilesManager.Instance.TileSpeed = 0;
            yield return null;

            // Instance a warrior
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.MaxRage = 100;
            wStats.MaxHealth = 10;
            wStats.Attack = 5;
            wStats.Defense = 0;
            wStats.XP = 0;
            warrior.Init(wStats);

            // Get the initial position and bump the wall
            float initialZPosition = wall.transform.position.z;
            warrior.BumpEntity(wall, 2);
            yield return null;

            // Check if the assassin was bumped
            Assert.AreEqual(initialZPosition, wall.transform.position.z);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Check if a wall can start and stop tiles with event and on death
        /// </summary>
        [UnityTest]
        public IEnumerator WallStartAndStopTilesTest()
        {
            // Instance wall
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Wall wall = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.wall).GetComponent<Wall>();
            yield return null;

            // Check if tiles are not stopped
            Assert.AreNotEqual(0, TilesManager.Instance.TileSpeed);
            
            // Stop the tiles
            wall.NearHeroTrigger.Invoke();
            yield return null;

            // Check if tiles are stopped
            Assert.AreEqual(0, TilesManager.Instance.TileSpeed);

            // Kill the wall
            wall.Die();
            yield return new WaitForSeconds(0.5f);

            // Check if tiles move again
            Assert.AreNotEqual(0, TilesManager.Instance.TileSpeed);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
