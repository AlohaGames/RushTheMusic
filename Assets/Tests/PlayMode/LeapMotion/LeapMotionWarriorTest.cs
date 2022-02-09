using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

//TODO: explain your TEST (like @Youen in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// This class test the LeapMotion scripts functions.
    /// </summary>
    public class LeapMotionWarriorTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        [UnityTest]
        public IEnumerator Test_SwordOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            wStats.MaxRage = 100;
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
            EnemyStats eStats = (EnemyStats) EnemyStats.CreateInstance("EnemyStats");
            eStats.MaxHealth = 10;
            enemy.Init(eStats);

            BoxCollider enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            warrior.IsAttacking = true;
            sword.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            //Assert.Greater(enemy.transform.position.z, 3f);
            //Assert.AreEqual(5, enemy.CurrentHealth);


            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// TODO
        /// </summary>
        [UnityTest]
        public IEnumerator Test_ShieldOnTriggerEnter()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
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
            EnemyStats eStats = (EnemyStats) EnemyStats.CreateInstance("EnemyStats");
            eStats.MaxHealth = 10;
            enemy.Init(eStats);

            BoxCollider enemyBoxCollider = enemyGO.AddComponent<BoxCollider>();
            enemyBoxCollider.tag = "Enemy";

            shield.OnTriggerEnter(enemyBoxCollider);

            yield return new WaitForSeconds(0.5f);

            //Assert.Greater(enemy.transform.position.z, 3f);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
