using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    public class ActionZoneTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        [UnityTest]
        public IEnumerator EnemyInstancierTest()
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
            GameObject.Destroy(parentGO);
            GameObject.Destroy(enemy.gameObject);
            GameObject.Destroy(manager);
            yield return null;
        }
    }
}
