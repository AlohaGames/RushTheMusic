using UnityEngine;
using NUnit.Framework;
using Aloha;
using Aloha.Events;

namespace Aloha.Test
{
    public class ScoreTest
    {
        [Test]
        public void ScoreHeroHit()
        {
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            instanceScoreManager.CountHeroHit();
            Assert.AreEqual(1, instanceScoreManager.GetTakeHit());

            GlobalEvent.HeroTakeDamage.Invoke();
            Assert.AreEqual(2, instanceScoreManager.GetTakeHit());
            Assert.AreEqual(40, instanceScoreManager.ScoreHit());

            for (int i = 0; i < 5; i++)
            {
                instanceScoreManager.CountHeroHit();
            }
            Assert.AreEqual(100, instanceScoreManager.ScoreHit());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(500, instanceScoreManager.totalScore);

            GameObject.DestroyImmediate(instanceScoreManager.gameObject);
        }

        [Test]
        public void ScoreKillCount()
        {
            ScoreManager instanceScoreManager = ScoreManager.Instance;
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            GameObject guerrierGO = new GameObject();
            Warrior guerrier = guerrierGO.AddComponent<Warrior>();

            instanceScoreManager.DeathCount(enemy);
            Assert.AreEqual(1, instanceScoreManager.GetKillCount());

            GlobalEvent.EntityDied.Invoke(enemy);
            Assert.AreEqual(2, instanceScoreManager.GetKillCount());
            Assert.AreEqual(60, instanceScoreManager.ScoreKill());

            //FIXME
            instanceScoreManager.DeathCount(guerrier);
            //Assert.AreEqual(2, instanceScoreManager.GetKillCount());

            for (int i = 0; i < 10; i++)
            {
                instanceScoreManager.DeathCount(enemy);
            }
            Assert.AreEqual(300, instanceScoreManager.ScoreKill());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(900, instanceScoreManager.totalScore);


            GameObject.DestroyImmediate(guerrierGO);
            GameObject.DestroyImmediate(enemyGO);
            GameObject.DestroyImmediate(instanceScoreManager.gameObject);
        }
    }
}