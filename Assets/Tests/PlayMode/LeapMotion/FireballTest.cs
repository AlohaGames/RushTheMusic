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
            yield return null;
            yield return null;

            Assert.AreNotEqual(firstPosition, fireball.transform.position);
            yield return new WaitForSeconds(2);

            Assert.IsTrue(fireball == null);
            Assert.IsTrue(fireballGO == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /*[UnityTest]
        public IEnumerator FireballOnTriggerEnterTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));

            Lancer lancer = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.lancer)
                .GetComponent<Lancer>();

            HeroInstantier.Instance.InstantiateHero(HeroType.Wizard);
            Hero hero = GameManager.Instance.GetHero();
            Wizard wizard = hero as Wizard;

            GameObject fireballGO = new GameObject();
            Fireball fireball = fireballGO.AddComponent<Fireball>();
            fireballGO.AddComponent<Rigidbody>();
            fireball.Wizard = wizard;
            fireball.Power = 1;

            BoxCollider fireballCollider = fireballGO.AddComponent<BoxCollider>();
            fireballCollider.isTrigger = true;
            fireball.Launch();

            BoxCollider lancerCollider = lancer.GetComponent<BoxCollider>();
            Assert.IsTrue(lancerCollider != null);

            yield return null;

            Assert.IsTrue(fireball == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }*/
    }
}
