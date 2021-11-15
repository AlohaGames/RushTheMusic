using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    public class EnemyTest
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EnemyTestDamage()
        {
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats stats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats");
            stats.maxHealth = 10;
            enemy.Init(stats);

            enemy.TakeDamage(5);
            Assert.AreEqual(5, enemy.currentHealth);

            enemy.TakeDamage(-5);
            Assert.AreEqual(5, enemy.currentHealth);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            enemy.TakeDamage(5);
            Assert.AreEqual(0, enemy.currentHealth);

            yield return null;

            Assert.IsTrue(enemy == null);

            if (enemyGO)
            {
                GameObject.Destroy(enemyGO);
            }

            Aloha.Utils.ClearCurrentScene();
        }

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

            
            Aloha.Utils.ClearCurrentScene(true);
        }

    }
}
