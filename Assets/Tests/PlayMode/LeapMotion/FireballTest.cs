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
        /// 
        /// </summary>
        [UnityTest]
        public IEnumerator LaunchFireballTest()
        {
            GameObject fireballGO = new GameObject();
            Fireball fireball = fireballGO.AddComponent<Fireball>();
            fireballGO.AddComponent<Rigidbody>();

            Vector3 firstPosition = fireball.transform.position;
            fireball.Launch();
            yield return new WaitForSeconds(1);

            Assert.AreNotEqual(firstPosition, fireball.transform.position);
            yield return new WaitForSeconds(1);

            Assert.IsTrue(fireball == null);
            Assert.IsTrue(fireballGO == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// 
        /// </summary>
        [UnityTest]
        public IEnumerator FireballOnTriggerEnterTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            GameObject wizardGO = new GameObject();
            Wizard wizard = wizardGO.AddComponent<Wizard>();
            WizardStats wizardStats = (WizardStats)ScriptableObject.CreateInstance("WizardStats");
            wizardStats.MaxMana = 100;
            wizardStats.MaxHealth = 10;
            wizardStats.Attack = 10;
            wizardStats.Defense = 10;
            wizardStats.XP = 10;
            wizard.Init(wizardStats);

            Enemy enemy = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.generic)
                .GetComponent<Enemy>();
            enemy.CurrentHealth = 100000;

            yield return null;

            GameObject fireballGO = new GameObject();
            Fireball fireball = fireballGO.AddComponent<Fireball>();
            fireballGO.AddComponent<Rigidbody>();
            fireball.Wizard = wizard;
            fireball.Power = 10;

            BoxCollider fireballCollider = fireballGO.AddComponent<BoxCollider>();
            fireballCollider.isTrigger = true;
            fireball.Launch();

            Collider enemyCollider = enemy.GetComponent<Collider>();
            Assert.IsTrue(enemyCollider != null);

            yield return null;

            Assert.IsTrue(fireball == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
