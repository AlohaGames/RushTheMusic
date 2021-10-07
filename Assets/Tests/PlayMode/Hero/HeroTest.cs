using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha.EntityStats;
using Aloha.Hero;

namespace Aloha.Test
{
    public class HeroTest
    {
        [Test]
        public void HeroInstantierTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Guerrier hero = HeroInstantier.Instance.InstantiateHero(HeroType.guerrier).GetComponent<Guerrier>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Guerrier);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);
        }

        [Test]
        public void HeroStatsTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Guerrier hero = HeroInstantier.Instance.InstantiateHero(HeroType.guerrier).GetComponent<Guerrier>();

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
            stats.maxFureur = 10;
            stats.maxHealth = 10;
            stats.attackPower = 10;
            stats.defensePower = 10;
            stats.xp = 10;
            guerrier.Init(stats);

            guerrier.TakeDamage(5);
            Assert.AreEqual(5, guerrier.health);

            guerrier.TakeDamage(-5);
            Assert.AreEqual(5, guerrier.health);

            yield return null;
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