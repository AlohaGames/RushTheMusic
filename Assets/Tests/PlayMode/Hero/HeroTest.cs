using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Aloha.Test
{
    /// <summary>
    /// This class test the hero class functions.
    /// </summary>
    public class HeroTest
    {
        /// <summary>
        /// Test if HeroInstancier work well
        /// </summary>
        [Test]
        public void HeroInstantierTest()
        {
            //Instantiate a hero
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Warrior);
            Hero hero = GameManager.Instance.GetHero();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Warrior);

            Aloha.Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Test the instantiation of a hero stats
        /// </summary>
        [Test]
        public void HeroStatsTest()
        {
            //Instantiate a hero
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            HeroInstantier.Instance.InstantiateHero(HeroType.Warrior);
            Hero hero = GameManager.Instance.GetHero();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Warrior);
            Assert.IsTrue(hero.GetStats() != null);
            Assert.IsTrue(hero.GetStats() is WarriorStats);

            Aloha.Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Test the amount of damage taken by hero
        /// </summary>
        [UnityTest]
        public IEnumerator HeroTestDamage()
        {
            //Instantiate a hero and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 0;
            stats.XP = 10;
            warrior.Init(stats);

            Debug.Log("Hero life: " + warrior.CurrentHealth);
            Debug.Log("Hero defense: " + stats.Defense);

            //Check the health after taking damage
            warrior.TakeDamage(-5);
            Assert.AreEqual(10, warrior.CurrentHealth);

            yield return null;

            //Test calcul damage reduction 
            stats.Defense = 50;
            float damageReduction = warrior.CalculateDamageReduction();
            Assert.IsTrue(Utils.IsEqualFloat(damageReduction, 0.714f, 0.001f));

            //Test with defense = 0
            stats.Defense = 0;
            stats.MaxHealth = 10;
            Debug.Log("Hero life: " + warrior.CurrentHealth);
            Debug.Log("Hero defense: " + stats.Defense);
            warrior.TakeDamage(5);
            Assert.AreEqual(5, warrior.CurrentHealth);

            Debug.Log("Hero life: " + warrior.CurrentHealth);
            warrior.TakeDamage(2);
            Assert.AreEqual(3, warrior.CurrentHealth);

            yield return null;

            //Test with defense = 100
            stats.Defense = 100;
            warrior.CurrentHealth = 50;
            Debug.Log("Hero life: " + warrior.CurrentHealth);
            Debug.Log("Hero defense: " + stats.Defense);
            warrior.TakeDamage(200);
            Assert.AreEqual(17, warrior.CurrentHealth);

            Debug.Log("Hero life: " + warrior.CurrentHealth);
            warrior.TakeDamage(60);
            Assert.AreEqual(7, warrior.CurrentHealth);

            //Destroy all GameObjects
            Aloha.Utils.ClearCurrentScene();
        }

        /// <summary>
        /// Test if Hero can attack an Enemy
        /// </summary>
        [Test]
        public void HeroTestAttack()
        {
            //Instantiate a hero and his stats
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            stats.MaxRage = 10;
            stats.MaxHealth = 10;
            stats.Attack = 10;
            stats.Defense = 10;
            stats.XP = 10;
            warrior.Init(stats);

            //Instantiate an enemi and his stats
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats) ScriptableObject.CreateInstance("EnemyStats");
            enemyStats.MaxHealth = 100;
            enemy.Init(enemyStats);

            //Hero attack the enemi
            warrior.Attack(enemy);
            Assert.IsTrue(enemy.CurrentHealth < enemy.GetStats().MaxHealth);

            Aloha.Utils.ClearCurrentScene(true);
        }
    }
}
