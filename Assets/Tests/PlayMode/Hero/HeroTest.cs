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
            Guerrier hero = HeroInstantier.Instance.InstantiateHero(HeroType.Guerrier).GetComponent<Guerrier>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Guerrier);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);
        }

        [Test]
        public void HeroStatsTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Guerrier hero = HeroInstantier.Instance.InstantiateHero(HeroType.Guerrier).GetComponent<Guerrier>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Guerrier);
            Assert.IsTrue(hero.stats != null);
            Assert.IsTrue(hero.stats is GuerrierStats);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);
        }

        [UnityTest]
        public IEnumerator HeroTestDamage()
        {
            GameObject guerrierGO = new GameObject();
            Guerrier guerrier = guerrierGO.AddComponent<Guerrier>();
            GuerrierStats stats = (GuerrierStats)ScriptableObject.CreateInstance("GuerrierStats");
            stats.maxRage = 10;
            stats.maxHealth = 10;
            stats.attack = 10;
            stats.defense = 0;
            stats.xp = 10;
            guerrier.Init(stats);

            Debug.Log("Hero life: " + guerrier.currentHealth);
            Debug.Log("Hero defense: " + stats.defense);

            guerrier.TakeDamage(-5);
            Assert.AreEqual(10, guerrier.currentHealth);

            yield return null;

            //Test calcul damage reduction 
            stats.defense = 50;
            float damageReduction = guerrier.CalculateDamageReduction();
            Assert.IsTrue(Utils.EqualFloat(damageReduction, 0.714f, 0.001f));

            //Test with defense = 0
            stats.defense = 0;
            stats.maxHealth = 10;
            Debug.Log("Hero life: " + guerrier.currentHealth);
            Debug.Log("Hero defense: " + stats.defense);
            guerrier.TakeDamage(5);
            Assert.AreEqual(5, guerrier.currentHealth);
            
            Debug.Log("Hero life: " + guerrier.currentHealth);
            guerrier.TakeDamage(2);
            Assert.AreEqual(3, guerrier.currentHealth);

            yield return null;

            //Test with defense = 100
            stats.defense = 100;
            guerrier.currentHealth = 50;
            Debug.Log("Hero life: " + guerrier.currentHealth);
            Debug.Log("Hero defense: " + stats.defense);
            guerrier.TakeDamage(200);
            Assert.AreEqual(17, guerrier.currentHealth);

            Debug.Log("Hero life: " + guerrier.currentHealth);
            guerrier.TakeDamage(60);
            Assert.AreEqual(7, guerrier.currentHealth);
        }
    }
}