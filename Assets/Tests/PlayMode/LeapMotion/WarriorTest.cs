using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;
using Aloha;
using Aloha.Hero;
using Aloha.EntityStats;

namespace Aloha.Test
{
    public class WarriorTest
    {
        [UnityTest]
        public IEnumerator Test_SwordOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.maxRage = 0;
            wStats.maxHealth = 10;
            wStats.attack = 5;
            wStats.defense = 0;
            wStats.xp = 0;
            warrior.Init(wStats);

            GameObject swordGO = new GameObject();
            Sword sword = swordGO.AddComponent<Sword>();
            sword.transform.position = Vector3.zero;
            sword.warrior = warrior;
            sword.speed = 30;

            var shieldBoxCollider = swordGO.AddComponent<BoxCollider>();
            shieldBoxCollider.isTrigger = true;

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.transform.position = new Vector3(0, 0, 3f);
            EnemyStats eStats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats");
            eStats.maxHealth = 10;
            enemy.Init(eStats);

            var enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            sword.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            Assert.Greater(enemy.transform.position.z, 3f);
            Assert.AreEqual(enemy.currentHealth, 5);
        }

        [UnityTest]
        public IEnumerator Test_ShieldOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.maxRage = 0;
            wStats.maxHealth = 10;
            wStats.attack = 5;
            wStats.defense = 0;
            wStats.xp = 0;
            warrior.Init(wStats);

            GameObject shieldGO = new GameObject();
            Shield shield = shieldGO.AddComponent<Shield>();
            shield.transform.position = Vector3.zero;
            shield.warrior = warrior;
            shield.speed = 30;

            var shieldBoxCollider = shieldGO.AddComponent<BoxCollider>();
            shieldBoxCollider.isTrigger = true;

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.transform.position = new Vector3(0, 0, 3f);
            EnemyStats eStats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats"); 
            eStats.maxHealth = 10;
            enemy.Init(eStats);

            var enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            shield.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            Assert.Greater(enemy.transform.position.z, 3f);
        }
    }
}
