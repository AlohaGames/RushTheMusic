using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    public class WarriorTest
    {
        /// <summary>
        /// Test the rage regeneration per hit
        /// </summary>
        [Test]
        public void WarriorRageTakeDamageRegenerationTest()
        {
            //Instantiate a warrior and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            //Check if max rage is correct
            Assert.AreEqual(10, warrior.GetStats().MaxRage);

            //Check the gain of rage when warrior taking damages
            warrior.CurrentRage = 5;
            Assert.AreEqual(5, warrior.CurrentRage);

            warrior.TakeDamage(2);
            Assert.AreEqual(7, warrior.CurrentRage);

            Aloha.Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Test the use of rage when warrior attacking
        /// </summary>
        [Test]
        public void WarriorRageAttackTest()
        {
            //Instantiate a warrior and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 2;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            //Instantiate an enemi and his stats
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats) ScriptableObject.CreateInstance("EnemyStats");
            enemyStats.MaxHealth = 20;
            enemy.Init(enemyStats);

            //Check if max rage is correct
            Assert.AreEqual(10, warrior.GetStats().MaxRage);

            //Check the gain of rage when warrior attack
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

        /// <summary>
        /// Test the rage potion regeneration
        /// </summary>
        [Test]
        public void WarriorRegenerationRagePotionTest()
        {
            //Instantiate a warrior and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 100;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            //Check if max rage is correct
            Assert.AreEqual(100, warrior.GetStats().MaxRage);

            //Take out rage
            warrior.CurrentRage = 0;

            //Regenerate 10% of rage max
            warrior.RegenerateSecondary(0.1f);
            Assert.AreEqual(10, warrior.CurrentRage);

            //Regenerate 55% of rage max
            warrior.RegenerateSecondary(0.55f);
            Assert.AreEqual(65, warrior.CurrentRage);

            //Take out rage
            warrior.CurrentRage = 0;

            //Regenerate 100% of rage max
            warrior.RegenerateSecondary(1f);
            Assert.AreEqual(100, warrior.CurrentRage);

            //Destroy all GameObjects
            GameObject.Destroy(warriorGO);
        }

        /// <summary>
        /// Test the rage potion regeneration over max rage
        /// </summary>
        [Test]
        public void WarriorRegenerationRagePotionOverMaxRageTest()
        {
            //Instantiate a warrior and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 100;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            //Check if max rage is correct
            Assert.AreEqual(100, warrior.GetStats().MaxRage);

            //Get max rage
            warrior.CurrentRage = stats.MaxRage;

            //Regenerate 10% of rage max
            warrior.RegenerateSecondary(0.1f);
            Assert.AreEqual(100, warrior.CurrentRage);

            //Regenerate 100% of rage max
            warrior.RegenerateSecondary(1f);
            Assert.AreEqual(100, warrior.CurrentRage);

            //Destroy all GameObjects
            GameObject.Destroy(warriorGO);
        }

        /// <summary>
        /// Test the rage potion with negative regeneration
        /// </summary>
        [Test]
        public void WarriorNegativeRegenerationRagePotionTest()
        {
            //Instantiate a warrior and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 100;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            //Check if max rage is correct
            Assert.AreEqual(100, warrior.GetStats().MaxRage);

            //Get max rage
            warrior.CurrentRage = stats.MaxRage;

            //Regenerate 100% of rage max
            warrior.RegenerateSecondary(-1f);
            Assert.AreEqual(100, warrior.CurrentRage);

            //Get base value rage
            warrior.CurrentRage = 0;

            //Regenerate 10% of rage max
            warrior.RegenerateSecondary(-0.1f);
            Assert.AreEqual(10, warrior.CurrentRage);

            //Destroy all GameObjects
            GameObject.Destroy(warriorGO);
        }
    }
}
