using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    /// <summary>
    /// Test the lancer's fonctions
    /// </summary>
    public class LancerTest
    {
        /// <summary>
        /// Check the instantiation of lancer
        /// </summary>
        [UnityTest]
        public IEnumerator LancerInstantiateTest()
        {
            // Instance lancer
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Lancer lancer = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.lancer).GetComponent<Lancer>();
            yield return null;

            // Check if lancer was instantiate well
            Assert.IsTrue(lancer != null);
            Assert.IsTrue(lancer is Lancer);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}