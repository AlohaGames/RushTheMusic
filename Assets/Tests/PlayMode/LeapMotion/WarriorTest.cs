using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

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
        [UnityTest]
        public IEnumerator Test_SwordOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.MaxRage = 0;
            wStats.MaxHealth = 10;
            wStats.Attack = 5;
            wStats.Defense = 0;
            wStats.XP = 0;
            warrior.Init(wStats);

            GameObject swordGO = new GameObject();
            Sword sword = swordGO.AddComponent<Sword>();
            sword.transform.position = Vector3.zero;
            sword.Warrior = warrior;
            sword.Speed = 30;

            BoxCollider swordBoxCollider = swordGO.AddComponent<BoxCollider>();
            swordBoxCollider.isTrigger = true;

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.transform.position = new Vector3(0, 0, 3f);
            EnemyStats eStats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats");
            eStats.MaxHealth = 10;
            enemy.Init(eStats);

            BoxCollider enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            sword.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            Assert.Greater(enemy.transform.position.z, 3f);
            Assert.AreEqual(enemy.CurrentHealth, 5);

            GameObject.Destroy(warrior);
            GameObject.Destroy(swordGO);
            GameObject.Destroy(enemyGO);
        }

        /// <summary>
        /// TODO
        /// </summary>
        [UnityTest]
        public IEnumerator Test_ShieldOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.MaxRage = 0;
            wStats.MaxHealth = 10;
            wStats.Attack = 5;
            wStats.Defense = 0;
            wStats.XP = 0;
            warrior.Init(wStats);

            GameObject shieldGO = new GameObject();
            Shield shield = shieldGO.AddComponent<Shield>();
            shield.transform.position = Vector3.zero;
            shield.Warrior = warrior;
            shield.Speed = 30;

            BoxCollider shieldBoxCollider = shieldGO.AddComponent<BoxCollider>();
            shieldBoxCollider.isTrigger = true;

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.transform.position = new Vector3(0, 0, 3f);
            EnemyStats eStats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats"); 
            eStats.MaxHealth = 10;
            enemy.Init(eStats);

            BoxCollider enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            shield.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            Assert.Greater(enemy.transform.position.z, 3f);

            GameObject.Destroy(warrior);
            GameObject.Destroy(shieldGO);
            GameObject.Destroy(enemyGO);
        }
    }
}
