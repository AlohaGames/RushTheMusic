using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

//TODO: explain your F***** TEST (like @Youen in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// TODO
    /// </summary>
    public class WarriorTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void WarriorRageTakeDamageRegenerationTest()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.GetStats().MaxRage);

            warrior.CurrentRage = 5;
            Assert.AreEqual(5, warrior.CurrentRage);

            warrior.TakeDamage(2);
            Assert.AreEqual(7, warrior.CurrentRage);

            Aloha.Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void WarriorRageAttackTest()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 2;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.GetStats().MaxRage);

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats) ScriptableObject.CreateInstance("EnemyStats");
            enemyStats.MaxHealth = 20;
            enemy.Init(enemyStats);

            warrior.Attack(enemy);
            Assert.AreEqual(2, warrior.CurrentRage);

            for (int i = 0; i <= 5; i++)
            {
                if (enemy == null)
                {
                    Assert.LessOrEqual(warrior.CurrentRage, warrior.GetStats().MaxRage);
                    break;
                }
                warrior.Attack(enemy);
            }

            Aloha.Utils.ClearCurrentScene(true);
        }
    }
}
