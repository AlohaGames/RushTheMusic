using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class WyrmlingFireballTest
    {
        /// <summary>
        /// Test wyrmling fireball trigger enter
        /// </summary>
        [UnityTest]
        public IEnumerator WyrmlingFireballOnTriggerEnterTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            // Instance a wizard
            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            wizard.transform.position = new Vector3(1000, 0, 0);
            wizard.tag = "Player";

            // Instance wizard stats
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 100;
            wizardStats.MaxHealth = 1000;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            // Instance a wyrmling
            Wyrmling wyrmling = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.wyrmling)
                .GetComponent<Wyrmling>();
            yield return null;

            // Instance a fireball
            GameObject fireballGO = new GameObject();
            WyrmlingFireball fireball = fireballGO.AddComponent<WyrmlingFireball>();
            fireballGO.AddComponent<Rigidbody>();
            fireball.AssociatedEnemy = wyrmling;
            fireball.transform.position = new Vector3(1000, 1000, 1000);

            // Instance the fireball collider
            BoxCollider fireballCollider = fireballGO.AddComponent<BoxCollider>();
            fireballCollider.isTrigger = true;

            // Get wizard collider
            BoxCollider wizardCollider = wizardGO.AddComponent<BoxCollider>();

            Assert.AreEqual("Player", wizard.tag, "player ?");

            // Trigger colliders
            fireball.OnTriggerEnter(wizardCollider);
            yield return null;

            Assert.IsTrue(fireball == null, "fireball not destroyed");

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
