using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha;

namespace Aloha.Test
{
    /// <summary>
    /// Test the assassin's fonctions
    /// </summary>
    public class AssassinTest
    {
        /// <summary>
        /// Check if a chest
        /// </summary>
        [UnityTest]
        public IEnumerator AssassinGetBumpTest()
        {
            // Instance assassin
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            Assassin assassin = EnemyInstantier.Instance.InstantiateEnemy(EnemyType.assassin).GetComponent<Assassin>();
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
            float initialZPosition = assassin.transform.position.z;
            warrior.BumpEntity(assassin, 2);
            yield return null;

            // Check if the assassin was bumped
            Assert.AreNotEqual(initialZPosition, assassin.transform.position.z);

            // Clear the scene
            Utils.ClearCurrentScene(true);
            yield return null;
        }
    }
}