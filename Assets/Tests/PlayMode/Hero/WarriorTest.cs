using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

//TODO: explain your FUNCKING TEST (like youyou in 17-Add-Lancer-Prefab tests of lancer)

namespace Aloha.Test
{
    public class WarriorTest
    {
        [Test]
        public void WarriorRageTakeDamageRegenerationTest(){
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
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

            GameObject.Destroy(warriorGO);
        }

        [Test]
        public void WarriorRageAttackTest(){
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 2;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.GetStats().MaxRage);

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats)ScriptableObject.CreateInstance("EnemyStats");
            enemyStats.MaxHealth = 20;
            enemy.Init(enemyStats);

            warrior.Attack(enemy);
            Assert.AreEqual(2, warrior.CurrentRage);

            for(int i = 0; i <= 5; i++){
                if(enemy == null){
                    Assert.LessOrEqual(warrior.CurrentRage, warrior.GetStats().MaxRage);
                    break;
                }
                warrior.Attack(enemy);
            }

            GameObject.Destroy(enemyGO);
            GameObject.Destroy(warriorGO);
        }
    }
}