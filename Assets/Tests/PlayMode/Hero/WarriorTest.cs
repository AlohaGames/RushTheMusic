using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Aloha.Test
{
    public class WarriorTest
    {
        [Test]
        public void WarriorRageTakeDamageRegenerationTest()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.maxRage = 10;
            stats.maxHealth = 10;
            stats.attack = 10;
            stats.defense = 10;
            stats.xp = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.GetStats().maxRage);

            warrior.currentRage = 5;
            Assert.AreEqual(5, warrior.currentRage);

            warrior.TakeDamage(2);
            Assert.AreEqual(7, warrior.currentRage);

            GameObject.Destroy(warriorGO);

            Aloha.Utils.ClearCurrentScene(true);
        }

        [Test]
        public void WarriorRageAttackTest()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.maxRage = 10;
            stats.maxHealth = 10;
            stats.attack = 2;
            stats.defense = 10;
            stats.xp = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.GetStats().maxRage);

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats)ScriptableObject.CreateInstance("EnemyStats");
            enemyStats.maxHealth = 20;
            enemy.Init(enemyStats);

            warrior.Attack(enemy);
            Assert.AreEqual(2, warrior.currentRage);

            for (int i = 0; i <= 5; i++)
            {
                if (enemy == null)
                {
                    Assert.LessOrEqual(warrior.currentRage, warrior.GetStats().maxRage);
                    break;
                }
                warrior.Attack(enemy);
            }

            GameObject.Destroy(enemyGO);
            GameObject.Destroy(warriorGO);

            Aloha.Utils.ClearCurrentScene(true);
        }
    }
}
