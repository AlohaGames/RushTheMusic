using UnityEngine;
using NUnit.Framework;
using Aloha;
using Aloha.Events;

namespace Aloha.Test
{
    public class ScoreTest {
        private ScoreManager instanceScoreManager = ScoreManager.Instance;
        private Entity entity;
        private Warrior hero;

        [Test]
        public void ScoreHeroHit(){
            instanceScoreManager.CountHeroHit();
            Assert.AreEqual(1, instanceScoreManager.GetTakeHit());

            GlobalEvent.HeroTakeDamage.Invoke();
            Assert.AreEqual(2, instanceScoreManager.GetTakeHit());
            Assert.AreEqual(40, instanceScoreManager.ScoreHit());

            for(int i = 0; i < 5; i++){
                instanceScoreManager.CountHeroHit();
            }
            Assert.AreEqual(100, instanceScoreManager.ScoreHit());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(500, instanceScoreManager.totalScore);
        }

        [Test]
        public void ScoreKillCount(){
            instanceScoreManager.DeathCount(entity);
            Assert.AreEqual(1, instanceScoreManager.GetKillCount());

            GlobalEvent.EntityDied.Invoke(entity);
            Assert.AreEqual(2, instanceScoreManager.GetKillCount());
            Assert.AreEqual(60, instanceScoreManager.ScoreKill());

            //FIXME
            instanceScoreManager.DeathCount(hero);
            Assert.AreEqual(2, instanceScoreManager.GetKillCount());

            for(int i = 0; i < 10; i++){
                instanceScoreManager.DeathCount(entity);
            }
            Assert.AreEqual(300, instanceScoreManager.ScoreKill());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(900, instanceScoreManager.totalScore);
        }
    }
}