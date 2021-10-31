using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    /// <summary>
    /// This class test the enemy class functions.
    /// </summary>
    public class EnemyTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        [UnityTest]
        public IEnumerator EnemyTestDamage()
        {
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats stats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats");
            stats.MaxHealth = 10;
            enemy.Init(stats);

            enemy.TakeDamage(5);
            Assert.AreEqual(5, enemy.CurrentHealth);

            enemy.TakeDamage(-5);
            Assert.AreEqual(5, enemy.CurrentHealth);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            enemy.TakeDamage(5);
            Assert.AreEqual(0, enemy.CurrentHealth);

            yield return null;

            Assert.IsTrue(enemy == null);

            if (enemyGO)
            {
                GameObject.Destroy(enemyGO);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void EnemyInstancierTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Enemy enemy = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.generic)
                .GetComponent<Enemy>();

            Assert.IsTrue(enemy != null);
            Assert.IsTrue(enemy is Enemy);

            GameObject.Destroy(enemy.gameObject);
            GameObject.Destroy(manager);
        }
    }
}