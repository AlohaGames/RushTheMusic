using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using Aloha.Events;

namespace Aloha.Test
{
    /// <summary>
    /// This class test the ScoreManager class functions.
    /// </summary>
    public class ScoreTest
    {
        //TODO: refaire tous les tests
        /*
        [UnityTest]
        public IEnumerator ScoreHeroHitTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            LevelManager instanceLevelManager = LevelManager.Instance;
            //Create enemies
            Stats enemyStats = ScriptableObject.CreateInstance<Stats>();
            enemyStats.attack = 10;
            enemyStats.defense = 10;
            enemyStats.maxHealth = 10;
            enemyStats.level = 2;
            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPosition.BOT, HorizontalPosition.CENTER);
            List<EnemyMapping> tile10Enemies = new List<EnemyMapping>();
            tile10Enemies.Add(genericEnemy);
            SerializeDictionary<int, List<EnemyMapping>> enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            enemies.Add(10, tile10Enemies);
            instanceLevelManager.levelMapping = new LevelMapping(enemies, 20);
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            yield return null;

            instanceScoreManager.CountHeroHit();
            Assert.AreEqual(1, instanceScoreManager.TakeHitCounter);

            GlobalEvent.HeroTakeDamage.Invoke();
            Assert.AreEqual(2, instanceScoreManager.TakeHitCounter);
            Assert.AreEqual(40, instanceScoreManager.ScoreHit());

            for (int i = 0; i < 5; i++)
            {
                instanceScoreManager.CountHeroHit();
            }
            Assert.AreEqual(100, instanceScoreManager.ScoreHit());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(500, instanceScoreManager.TotalScore);

            GameObject.DestroyImmediate(manager);
        }

        [Test]
        public void ScoreHeroHitThrowErrorTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            Assert.Catch<IndexOutOfRangeException>(() => instanceScoreManager.ScoreHit());
            Assert.Catch<IndexOutOfRangeException>(() => instanceScoreManager.CalculateTotalScore());

            GameObject.DestroyImmediate(manager);
        }

        [Test]
        public void ScoreKillCount()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            LevelManager instanceLevelManager = LevelManager.Instance;
            //Create enemy list
            Stats enemyStats = ScriptableObject.CreateInstance<Stats>();
            enemyStats.attack = 10;
            enemyStats.defense = 10;
            enemyStats.maxHealth = 10;
            enemyStats.level = 2;
            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPosition.BOT, HorizontalPosition.CENTER);
            List<EnemyMapping> tile10Enemies = new List<EnemyMapping>();
            tile10Enemies.Add(genericEnemy);
            SerializeDictionary<int, List<EnemyMapping>> enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            enemies.Add(10, tile10Enemies);
            instanceLevelManager.levelMapping = new LevelMapping(enemies, 20);

            Debug.Log("Number of enemies: " + instanceLevelManager.levelMapping.GetEnemyNumber());

            GameObject.DestroyImmediate(manager);
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
            Assert.AreEqual(1, instanceScoreManager.TilesCounter);

            GlobalEvent.TileCount.Invoke(tile);
            Assert.AreEqual(2, instanceScoreManager.TilesCounter);
            Assert.AreEqual(60, instanceScoreManager.ScoreDistance());

            for (int i = 0; i < 20; i++)
            {
                GlobalEvent.TileCount.Invoke(tile);
            }
            Assert.AreEqual(600, instanceScoreManager.ScoreDistance());
            instanceScoreManager.CalculateTotalScore();
            Assert.AreEqual(600, instanceScoreManager.TotalScore);

            GameObject.DestroyImmediate(tile);
            GameObject.DestroyImmediate(manager);
        }

        [Test]
        public void ScoreDistanceThrowErrorTest()
        {
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GlobalManager"));
            LevelManager instanceLevelManager = LevelManager.Instance;
            instanceLevelManager.levelMapping = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(), -1);
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            Assert.Catch<IndexOutOfRangeException>(() => instanceScoreManager.ScoreDistance());
            Assert.Catch<IndexOutOfRangeException>(() => instanceScoreManager.CalculateTotalScore());

            GameObject.DestroyImmediate(manager);
        }
        */
    }
}