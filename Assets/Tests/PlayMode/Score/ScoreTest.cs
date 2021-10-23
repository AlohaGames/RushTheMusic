using UnityEngine;
using NUnit.Framework;
using Aloha;
using Aloha.Events;
using System.Collections.Generic;

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

            //GameObject.DestroyImmediate(instanceScoreManager.gameObject);
        }

        [Test]
        public void ScoreKillCount()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            LevelManager instanceLevelManager = LevelManager.Instance;
            //Create enemy list
            EnemyMapping mappignEnemy = new EnemyMapping();
            List<EnemyMapping> enemiesMapping = new List<EnemyMapping>();
            enemiesMapping.Add(mappignEnemy);
            List<int> keys = new List<int>();
            keys.Add(10);
            List<List<EnemyMapping>> enemies = new List<List<EnemyMapping>>();
            enemies.Add(enemiesMapping);
            instanceLevelManager.levelMapping = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(keys, enemies), 20); 


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
            //GameObject.DestroyImmediate(instanceScoreManager.gameObject);
        }

        [Test]
        public void ScoreDistanceTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            LevelManager instanceLevelManager = LevelManager.Instance;
            instanceLevelManager.levelMapping = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(), 20);
            ScoreManager instanceScoreManager = ScoreManager.Instance;
            GameObject tile = new GameObject();

            Assert.AreEqual(20, instanceLevelManager.levelMapping.tileCount);

            instanceScoreManager.TilesCount(tile);
            Assert.AreEqual(1, instanceScoreManager.GetTilesCount());

            GlobalEvent.TileCount.Invoke(tile);
            Assert.AreEqual(2, instanceScoreManager.GetTilesCount());
            Assert.AreEqual(60, instanceScoreManager.ScoreDistance());

            for (int i = 0; i < 20; i++)
            {
                GlobalEvent.TileCount.Invoke(tile);
            }
            Assert.AreEqual(600, instanceScoreManager.ScoreDistance());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(600, instanceScoreManager.totalScore);

            GameObject.Destroy(tile);
            GameObject.Destroy(manager);
        }
    }
}