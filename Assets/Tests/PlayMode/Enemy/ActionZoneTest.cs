using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// All tests about ActionZone class
    /// </summary>
    public class ActionZoneTest
    {
        /// <summary>
        /// Check if ActionZone work well around Enemy
        /// </summary>
        [UnityTest]
        public IEnumerator ActionZoneActivationTest()
        {
            // Instance enemy and manager
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Enemy enemy = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.generic).GetComponent<Enemy>();

            // Instance "Player" gameObject
            GameObject playerGO = new GameObject();
            Collider playerCollider = playerGO.AddComponent<BoxCollider>();
            playerGO.tag = "Player";

            // Intance parent to assign to enemy
            GameObject parentGO = new GameObject();
            enemy.transform.parent = parentGO.transform;

            // Check if enemy parent is parentGO
            Assert.IsTrue(enemy.transform.parent == parentGO.transform);

            // Check if AI is activated
            enemy.GetComponentInChildren<ActionZone>().OnTriggerEnter(playerCollider);
            Assert.IsTrue(enemy.transform.parent == null);
            enemy.SetAI(false);
            yield return new WaitForSeconds(2);

            // Destroy objects
            Aloha.Utils.ClearCurrentScene();
        }
    }
}
