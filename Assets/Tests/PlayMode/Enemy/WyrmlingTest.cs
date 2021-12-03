using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    /// <summary>
    /// Test the Wyrming's fonctions
    /// </summary>
    public class WyrmlingTest
    {
        /// <summary>
        /// Check if Wyrmling was bumped
        /// </summary>
        [UnityTest]
        public IEnumerator WyrmlingGetBumpTest()
        {
            // Instance wyrmling
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Wyrmling wyrmling = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.wyrmling).GetComponent<Wyrmling>();
            yield return null;

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

            // Get the initial position and bump the assassin
            float initialZPosition = wyrmling.transform.position.z;
            warrior.BumpEntity(wyrmling, 2);
            yield return null;

            // Check if the assassin was bumped
            Assert.AreNotEqual(initialZPosition, wyrmling.transform.position.z);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Check the instantiation of fireball
        /// </summary>
        [UnityTest]
        public IEnumerator WyrmlingFireballInstantiateTest()
        {
            // Instance wyrmling
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Wyrmling wyrmling = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.wyrmling).GetComponent<Wyrmling>();
            yield return null;

            // Instance fireball
            wyrmling.InstantiateFireball();
            yield return null;

            // Check if fireball was instantiated
            Assert.IsTrue(wyrmling.GetWyrmlingFireball() != null);
            Assert.IsTrue(wyrmling.GetWyrmlingFireball() is WyrmlingFireball);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        /// <summary>
        /// Check the launch of fireball
        /// </summary>
        [UnityTest]
        public IEnumerator WyrmlingFireballLaunchTest()
        {
            // Instance wyrmling
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Wyrmling wyrmling = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.wyrmling).GetComponent<Wyrmling>();
            wyrmling.transform.position = new Vector3 (2, 2, 2);
            yield return null;

            // Instance a warrior
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats wStats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            wStats.MaxRage = 100;
            wStats.MaxHealth = 400;
            wStats.Attack = 5;
            wStats.Defense = 0;
            wStats.XP = 0;
            warrior.Init(wStats);
            GameManager.Instance.SetHero(warrior);
            yield return null;

            // Instance fireball
            wyrmling.InstantiateFireball();
            yield return null;
            wyrmling.LaunchFireball(0.5f);

            // Check if fireball was instantiated
            Assert.IsTrue(wyrmling.GetWyrmlingFireball() == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}