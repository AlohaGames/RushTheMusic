using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;
using Aloha.EntityStats;

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
            Assert.AreEqual(5, enemy.health);

            enemy.TakeDamage(-5);
            Assert.AreEqual(5, enemy.health);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            enemy.TakeDamage(5);
            Assert.AreEqual(0, enemy.health);

            yield return null;

            Assert.IsTrue(enemy == null);

            //GameObject.Destroy(enemy);
        }

        [Test]
        public void EnemyInstancierTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Enemy enemy = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.generic)
                .GetComponent<Enemy>();

            Assert.IsTrue(enemy != null);
            Assert.IsTrue(enemy is Enemy);

            GameObject.Destroy(enemy);
            GameObject.Destroy(manager);
        }
    }
}