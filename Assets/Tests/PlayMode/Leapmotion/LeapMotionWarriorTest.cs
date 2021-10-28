using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    public class LeapMotionWarriorTest
    {
        [UnityTest]
        public IEnumerator Test_SwordOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.maxRage = 100;
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

            BoxCollider swordBoxCollider = swordGO.AddComponent<BoxCollider>();
            swordBoxCollider.isTrigger = true;

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.transform.position = new Vector3(0, 0, 3f);
            EnemyStats eStats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats");
            eStats.maxHealth = 10;
            enemy.Init(eStats);

            BoxCollider enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            sword.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            Assert.Greater(enemy.transform.position.z, 3f);
            Assert.AreEqual(5, enemy.currentHealth);

            GameObject.Destroy(enemyGO);
            GameObject.Destroy(swordGO);
            GameObject.Destroy(warriorGO);
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

            BoxCollider shieldBoxCollider = shieldGO.AddComponent<BoxCollider>();
            shieldBoxCollider.isTrigger = true;

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.transform.position = new Vector3(0, 0, 3f);
            EnemyStats eStats = (EnemyStats)EnemyStats.CreateInstance("EnemyStats"); 
            eStats.maxHealth = 10;
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
