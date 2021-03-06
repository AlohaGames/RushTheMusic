using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// This class test the enemy class functions.
    /// </summary>
    public class EnemyTest
    {
        /// <summary>
        /// Test if Enemy can take damage and Disapear when health reach 0
        /// </summary>
        [UnityTest]
        public IEnumerator EnemyTestDamage()
        {
            // Instantiation of an enemy
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats stats = (EnemyStats) EnemyStats.CreateInstance("EnemyStats");
            stats.MaxHealth = 10;
            enemy.Init(stats);

            // Hit the enemy
            enemy.TakeDamage(5);
            Assert.AreEqual(5, enemy.CurrentHealth);

            // Check if enemy is not healed with negatives damages
            enemy.TakeDamage(-5);
            Assert.AreEqual(5, enemy.CurrentHealth);
            yield return null;

            // Hit the enemy
            enemy.TakeDamage(5);
            Assert.AreEqual(0, enemy.CurrentHealth);

            // Wait for death animation
            yield return new WaitForSeconds(0.5f);

            // Check if enemy is killed
            Assert.IsTrue(enemy == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Test if EnemyInstancier work well
        /// </summary>
        [Test]
        public void EnemyInstancierTest()
        {
            // Instantiation of a generic enemy
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Enemy enemy = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.generic)
                .GetComponent<Enemy>();

            // Check if enemy has been instanced
            Assert.IsTrue(enemy != null);
            Assert.IsTrue(enemy is Enemy);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

    }
}
