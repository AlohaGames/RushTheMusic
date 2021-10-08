using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha.Hero;
using Aloha.EntityStats;

namespace Aloha.Test
{
    public class HeroTest
    {
        [Test]
        public void HeroInstantierTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Warrior hero = HeroInstantier.Instance.InstantiateHero(HeroType.Warrior).GetComponent<Warrior>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Warrior);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);
        }

        [Test]
        public void HeroStatsTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Warrior hero = HeroInstantier.Instance.InstantiateHero(HeroType.Warrior).GetComponent<Warrior>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Warrior);
            Assert.IsTrue(hero.stats != null);
            Assert.IsTrue(hero.stats is WarriorStats);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);
        }

        [UnityTest]
        public IEnumerator HeroTestDamage()
        {
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.maxRage = 10;
            stats.maxHealth = 10;
            stats.attack = 10;
            stats.defense = 0;
            stats.xp = 10;
            warrior.Init(stats);

            Debug.Log("Hero life: " + warrior.currentHealth);
            Debug.Log("Hero defense: " + stats.defense);

            warrior.TakeDamage(-5);
            Assert.AreEqual(10, warrior.currentHealth);

            yield return null;

            //Test calcul damage reduction 
            stats.defense = 50;
            float damageReduction = warrior.CalculateDamageReduction();
            Assert.IsTrue(Utils.EqualFloat(damageReduction, 0.714f, 0.001f));

            //Test with defense = 0
            stats.defense = 0;
            stats.maxHealth = 10;
            Debug.Log("Hero life: " + warrior.currentHealth);
            Debug.Log("Hero defense: " + stats.defense);
            warrior.TakeDamage(5);
            Assert.AreEqual(5, warrior.currentHealth);
            
            Debug.Log("Hero life: " + warrior.currentHealth);
            warrior.TakeDamage(2);
            Assert.AreEqual(3, warrior.currentHealth);

            yield return null;

            //Test with defense = 100
            stats.defense = 100;
            warrior.currentHealth = 50;
            Debug.Log("Hero life: " + warrior.currentHealth);
            Debug.Log("Hero defense: " + stats.defense);
            warrior.TakeDamage(200);
            Assert.AreEqual(17, warrior.currentHealth);

            Debug.Log("Hero life: " + warrior.currentHealth);
            warrior.TakeDamage(60);
            Assert.AreEqual(7, warrior.currentHealth);
        }

        [Test]
        public void HeroTestAttack()
        {
            GameObject guerrierGO = new GameObject();
            Guerrier guerrier = guerrierGO.AddComponent<Guerrier>();
            GuerrierStats stats = (GuerrierStats)ScriptableObject.CreateInstance("GuerrierStats");
            stats.maxFureur = 10;
            stats.maxHealth = 10;
            stats.attackPower = 10;
            stats.defensePower = 10;
            stats.xp = 10;
            guerrier.Init(stats);

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats)ScriptableObject.CreateInstance("EnemyStats");
            stats.maxHealth = 10;
            enemy.Init(enemyStats);

            guerrier.Attack(enemy);
            Debug.Log(enemy.health);
        }
    }
}