using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

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

            yield return null;

            enemy.TakeDamage(5);
            Assert.AreEqual(0, enemy.CurrentHealth);

            // Wait for death animation
            yield return new WaitForSeconds(0.5f);

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
