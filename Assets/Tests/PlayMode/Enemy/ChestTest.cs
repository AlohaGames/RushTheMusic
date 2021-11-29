using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    public class ChestTest
    {

        /// <summary>
        /// Check instantiation of a chest
        /// </summary>
        [Test]
        public void ChestInstancierTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Chest chest = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.chest)
                .GetComponent<Chest>();

            Assert.IsTrue(chest != null);
            Assert.IsTrue(chest is Chest);

            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Check if a chest is not bump by going through the GetBump()
        /// </summary>
        [UnityTest]
        public IEnumerator ChestGetBumpTest()
        {
            // Instance Chest
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Chest chest = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.chest)
                .GetComponent<Chest>();

            // Instance a warrior
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.MaxRage = 100;
            wStats.MaxHealth = 10;
            wStats.Attack = 5;
            wStats.Defense = 0;
            wStats.XP = 0;
            warrior.Init(wStats);

            // Instance a sword
            GameObject swordGO = new GameObject();
            Sword sword = swordGO.AddComponent<Sword>();
            sword.transform.position = Vector3.zero;
            sword.Warrior = warrior;
            sword.Speed = 30;

            // Config sword collider
            BoxCollider swordBoxCollider = swordGO.AddComponent<BoxCollider>();
            swordBoxCollider.isTrigger = true;

            // Trigger chest collider to bump it
            Vector3 initialPosition = chest.transform.position;
            sword.OnTriggerEnter(chest.GetComponent<Collider>());
            yield return null;

            // Check if chest is at the same position
            Assert.IsTrue(initialPosition == chest.transform.position);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /*
        /// <summary>
        /// Check if a chest gives an item on death
        /// </summary>
        [UnityTest]
        public IEnumerator ChestDiesTest()
        {
            // Instance Chest
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Chest chest = EnemyInstantier.Instance
                .InstantiateEnemy(EnemyType.chest)
                .GetComponent<Chest>();


            System.Collections.Generic.Queue<Item> items = InventoryManager.Instance.GetItems();
            Assert.AreEqual(0, items.Count);

            //chest.TakeDamage(10);
            chest.Die();
            yield return null;

            items = InventoryManager.Instance.GetItems();
            Assert.AreEqual(2, items.Count);

            yield return null;
        }*/
    }
}
