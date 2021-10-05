using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Heros;
using Aloha;

namespace Heros.Test
{
    public class HeroTest
    { /*
        [UnityTest]
        public IEnumerator HeroInstancierTest(){
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Hero hero = HeroInstantier.Instance.InstantiateHero(HeroType.generic, 10, 5).GetComponent<Hero>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Hero);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);

            // Use yield to skip a frame.
            yield return null;
        }

        public IEnumerator HeroTestDamage()
        {
            GameObject heroGO = new GameObject();
            Hero hero = heroGO.AddComponent<Hero>();
            hero.Init(10, 5);

            hero.TakeDamage(5);
            Assert.AreEqual(5, hero.health);

            hero.TakeDamage(-5);
            Assert.AreEqual(5, hero.health);

            yield return null;

            hero.TakeDamage(5);
            Assert.IsTrue(hero == null);
        }

        public IEnumerator HeroTestAttack()
        {
            GameObject heroGO = new GameObject();
            Hero hero = heroGO.AddComponent<Hero>();
            hero.Init(10, 5);
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            enemy.Init(15);

            hero.Attack(enemy);
            Assert.AreEqual(10, enemy.health);

            yield return null;

        }
        */
    }
}