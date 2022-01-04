using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    public class VortexTest
    {
        /// <summary>
        /// Test vortex trigger enter
        /// </summary>
        [UnityTest]
        public IEnumerator VortexOnTriggerEnterTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            // Instance wizard
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 1000;
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

            // Instance a vortex
            GameObject vortexGO = new GameObject();
            Vortex vortex = vortexGO.AddComponent<Vortex>();
            vortexGO.AddComponent<Rigidbody>();
            vortex.Wizard = wizard;
            vortex.Power = 10;
            vortex.transform.position = new Vector3(1000, 1000, 1000);

            // Create the fireball collider
            BoxCollider vortexCollider = vortexGO.AddComponent<BoxCollider>();
            vortexCollider.isTrigger = true;

            // Get the enemy collider
            Collider enemyCollider = enemy.GetComponent<Collider>();
            Assert.IsTrue(enemyCollider != null);

            // Trigger colliders
            Vector3 lastPosition = enemy.transform.position;
            vortex.OnTriggerEnter(enemyCollider);
            yield return null;

            // Check if vortex worked
            Assert.AreNotEqual(lastPosition, enemy.transform.position);
            Assert.IsTrue(vortex == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}