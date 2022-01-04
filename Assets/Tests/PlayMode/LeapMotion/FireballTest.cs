using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class FireballTest
    {
        /// <summary>
        /// Test the fireball launches
        /// </summary>
        [UnityTest]
        public IEnumerator LaunchFireballTest()
        {
            // Instance a fireball
            GameObject fireballGO = new GameObject();
            Fireball fireball = fireballGO.AddComponent<Fireball>();
            fireballGO.AddComponent<Rigidbody>();

            // Launch the fireball
            Vector3 firstPosition = fireball.transform.position;
            fireball.Launch();
            yield return new WaitForSeconds(1);

            // Check if the fireball moved
            Assert.AreNotEqual(firstPosition, fireball.transform.position);
            yield return new WaitForSeconds(1);

            // Check if the fireball destroyed after a specific time
            Assert.IsTrue(fireball == null);
            Assert.IsTrue(fireballGO == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Test fireball trigger enter
        /// </summary>
        [UnityTest]
        public IEnumerator FireballOnTriggerEnterTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            // Instance wizard
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 100;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            // Instance enemy
            Enemy enemy = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.generic)
                .GetComponent<Enemy>();
            enemy.CurrentHealth = 100000;
            yield return null;

            // Instance a fireball
            GameObject fireballGO = new GameObject();
            Fireball fireball = fireballGO.AddComponent<Fireball>();
            fireballGO.AddComponent<Rigidbody>();
            fireball.Wizard = wizard;
            fireball.Power = 10;
            fireball.transform.position = new Vector3(1000, 1000, 1000);

            // Create the fireball collider
            BoxCollider fireballCollider = fireballGO.AddComponent<BoxCollider>();
            fireballCollider.isTrigger = true;
            fireball.Launch();

            // Get the enemy collider
            Collider enemyCollider = enemy.GetComponent<Collider>();
            Assert.IsTrue(enemyCollider != null);
            yield return null;

            // Trigger colliders
            fireball.OnTriggerEnter(enemyCollider);
            yield return null;

            // Check if fireball deleted
            Assert.IsTrue(fireball == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
