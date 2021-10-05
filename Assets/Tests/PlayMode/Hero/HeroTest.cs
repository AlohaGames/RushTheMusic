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
        [UnityTest]
        public IEnumerator HeroInstantierTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            Guerrier hero = HeroInstantier.Instance.InstantiateHero(HeroType.guerrier).GetComponent<Guerrier>();

            Assert.IsTrue(hero != null);
            Assert.IsTrue(hero is Guerrier);

            GameObject.Destroy(hero);
            GameObject.Destroy(manager);

            yield return null;
        }

        [UnityTest]
        public IEnumerator HeroTestDamage()
        {
            GameObject guerrierGO = new GameObject();
            Guerrier guerrier = guerrierGO.AddComponent<Guerrier>();
            GuerrierStats stats = (GuerrierStats) ScriptableObject.CreateInstance("GuerrierStats");
            stats.maxFureur = 10;
            stats.maxHealth = 10;
            stats.attackPower = 10;
            stats.defensePower = 10;
            stats.xp = 10;
            Debug.Log(stats);
            guerrier.Init(stats);

            Debug.Log(guerrier.health);
            guerrier.TakeDamage(5);
            Debug.Log(guerrier.health);
            Assert.AreEqual(5, guerrier.health);

            yield return null;
        }
    }
}