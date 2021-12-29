using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class CanonBallTest
    {
        /// <summary>
        /// Test wyrmling fireball trigger enter
        /// </summary>
        [UnityTest]
        public IEnumerator CanonballOnTriggerEnterTest()
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
            wizardStats.MaxHealth = 100;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            // Instance a wyrmling
            Canon canon = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.canon)
                .GetComponent<Canon>();
            canon.Hero = wizard;
            yield return null;

            // Instance a canonball
            GameObject canonballGO = new GameObject();
            CanonBall canonball = canonballGO.AddComponent<CanonBall>();
            canonballGO.AddComponent<Rigidbody>();
            canonball.AssociatedEnemy = canon;
            canonball.transform.position = new Vector3(1000, 1000, 1000);

            // Instance the canonball collider
            BoxCollider canonballCollider = canonballGO.AddComponent<BoxCollider>();
            canonballCollider.isTrigger = true;

            // Get wizard collider
            BoxCollider wizardCollider = wizardGO.AddComponent<BoxCollider>();

            Assert.AreEqual("Player", wizard.tag, "player ?");

            // Trigger colliders
            canonball.OnTriggerEnter(wizardCollider);
            yield return null;

            Assert.IsTrue(canonball == null, "fireball not destroyed");
            yield return null;

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
