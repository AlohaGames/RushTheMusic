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
    /// This class tests the ScoreManager class functions.
    /// </summary>
    public class ScoreTest
    {
        /// <summary>
        /// This function creates level mappings / 
        /// Utilities method, it's not a test
        /// </summary>
        LevelMapping[] GetLevelMapping()
        {
            //Create enemy stats for the enemy mapping
            Stats enemyStats = ScriptableObject.CreateInstance<Stats>();
            enemyStats.Attack = 1;
            enemyStats.Defense = 0;
            enemyStats.MaxHealth = 1;
            enemyStats.Level = 1;

            //Create the level mapping 0 (with 4 enemies)
            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPositionEnum.BOT, HorizontalPositionEnum.CENTER);
            List<EnemyMapping> tile2enemies = new List<EnemyMapping>();
            tile2enemies.Add(genericEnemy);
            tile2enemies.Add(genericEnemy);
            tile2enemies.Add(genericEnemy);
            tile2enemies.Add(genericEnemy);
            SerializeDictionary<int, List<EnemyMapping>> enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            enemies.Add(2, tile2enemies);
            LevelMapping levelMapping0 = new LevelMapping(enemies, 10);

            //Create the level mapping 1 (without enemies)
            LevelMapping levelMapping1 = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(), 10);

            LevelMapping[] lms = { levelMapping0, levelMapping1 };
            return lms;
        }

        /// <summary>
        /// This function tests the hit score calcul with enemies
        /// </summary>
        [UnityTest]
        public IEnumerator ScoreHeroHitEnemiesTest()
        {
            //Create instance of game manager and ScoreManager
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            //Create the hero instance
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats warriorStats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            warriorStats.MaxRage = 10;
            warriorStats.MaxHealth = 10;
            warriorStats.Attack = 1;
            warriorStats.Defense = 0;
            warriorStats.XP = 0;
            warrior.Init(warriorStats);

            //Create the level mapping with 4 enemies
            LevelMapping levelMapping = GetLevelMapping()[0];
            LevelManager.Instance.LevelMapping = levelMapping;

            yield return null;

            //Call the HeroTakeDamage event
            warrior.TakeDamage(0);

            //Test hit score and total score
            Assert.AreEqual(50, instanceScoreManager.HitScore);
            Assert.AreEqual(-50, instanceScoreManager.TotalScore);

            yield return null;

            //Test hit score and total score
            for (int i = 0; i < 6; i++)
            {
                warrior.TakeDamage(0);
            }
            Assert.AreEqual(100, instanceScoreManager.HitScore);
            Assert.AreEqual(-100, instanceScoreManager.TotalScore);

            //Destroy GameObjects
            Aloha.Utils.ClearCurrentScene();
        }

        /// <summary>
        /// This function tests the hit score calcul without enemies
        /// </summary>
        [UnityTest]
        public IEnumerator ScoreHeroHitWithoutEnemiesTest()
        {
            //Create instance of game manager and ScoreManager
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            //Create the hero instance
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats warriorStats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            warriorStats.MaxRage = 10;
            warriorStats.MaxHealth = 10;
            warriorStats.Attack = 1;
            warriorStats.Defense = 0;
            warriorStats.XP = 0;
            warrior.Init(warriorStats);

            //Create the level mapping without enemies
            LevelMapping levelMapping = GetLevelMapping()[1];
            LevelManager.Instance.LevelMapping = levelMapping;

            yield return null;

            //Call the HeroTakeDamage event
            warrior.TakeDamage(0);

            //Test hit score and total score
            Assert.AreEqual(0, instanceScoreManager.HitScore);
            Assert.AreEqual(0, instanceScoreManager.TotalScore);

            yield return null;

            //Test hit score and total score
            for (int i = 0; i < 6; i++)
            {
                warrior.TakeDamage(0);
            }
            Assert.AreEqual(0, instanceScoreManager.HitScore);
            Assert.AreEqual(0, instanceScoreManager.TotalScore);

            //Destroy GameObjects
            Aloha.Utils.ClearCurrentScene();
        }

        /// <summary>
        /// This function tests the kill score calcul with 4 enemies
        /// </summary>
        [UnityTest]
        public IEnumerator ScoreKillEnemiesCount()
        {
            //Create game instance and ScoreManager instance
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            //Create the hero instance
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats warriorStats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            warriorStats.MaxRage = 10;
            warriorStats.MaxHealth = 10;
            warriorStats.Attack = 1;
            warriorStats.Defense = 0;
            warriorStats.XP = 0;
            warrior.Init(warriorStats);

            //Create enemy instance
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats) EnemyStats.CreateInstance("EnemyStats");
            enemyStats.MaxHealth = 1;
            enemy.Init(enemyStats);

            //Create the level mapping with 4 enemies
            LevelMapping levelMapping = GetLevelMapping()[0];
            LevelManager.Instance.LevelMapping = levelMapping;

            yield return null;

            //Kill 1 enemy
            instanceScoreManager.DeathCount(enemy);
            Assert.AreEqual(75, instanceScoreManager.EnemyKilledScore);
            Assert.AreEqual(75, instanceScoreManager.TotalScore);

            yield return null;

            //Kill many enemies
            for (int i = 0; i < 6; i++)
            {
                instanceScoreManager.DeathCount(enemy);
            }
            Assert.AreEqual(300, instanceScoreManager.EnemyKilledScore);
            Assert.AreEqual(300, instanceScoreManager.TotalScore);

            //Destroy GameObjects
            Aloha.Utils.ClearCurrentScene();
        }

        /// <summary>
        /// This function tests the kill score calcul without enemies
        /// </summary>
        [UnityTest]
        public IEnumerator ScoreKillWithoutEnemiesCount()
        {
            //Create game instance and ScoreManager instance
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            //Create the hero instance
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats warriorStats = (WarriorStats) ScriptableObject.CreateInstance("WarriorStats");
            warriorStats.MaxRage = 10;
            warriorStats.MaxHealth = 10;
            warriorStats.Attack = 1;
            warriorStats.Defense = 0;
            warriorStats.XP = 0;
            warrior.Init(warriorStats);

            //Create enemy instance
            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats) EnemyStats.CreateInstance("EnemyStats");
            enemyStats.MaxHealth = 1;
            enemy.Init(enemyStats);

            //Create the level mapping with 4 enemies
            LevelMapping levelMapping = GetLevelMapping()[1];
            LevelManager.Instance.LevelMapping = levelMapping;

            yield return null;

            //Kill 1 enemy
            instanceScoreManager.DeathCount(enemy);
            Assert.AreEqual(0, instanceScoreManager.EnemyKilledScore);
            Assert.AreEqual(0, instanceScoreManager.TotalScore);

            yield return null;

            //Kill many enemies
            for (int i = 0; i < 6; i++)
            {
                instanceScoreManager.DeathCount(enemy);
            }
            Assert.AreEqual(0, instanceScoreManager.EnemyKilledScore);
            Assert.AreEqual(0, instanceScoreManager.TotalScore);

            //Destroy GameObjects
            Aloha.Utils.ClearCurrentScene();
        }

        /// <summary>
        /// This function tests the distance score calcul with tiles
        /// </summary>
        [UnityTest]
        public IEnumerator ScoreDistanceTest()
        {
            //Create game instance and ScoreManager instance
            GameObject manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            ScoreManager instanceScoreManager = ScoreManager.Instance;

            //Create tile object
            GameObject tile = new GameObject();

            //Create the level mapping with 4 enemies
            LevelMapping levelMapping = GetLevelMapping()[1];
            LevelManager.Instance.LevelMapping = levelMapping;

            yield return null;

            //Passing a tile
            instanceScoreManager.TilesCount(tile);
            Assert.AreEqual(60, instanceScoreManager.DistanceScore);
            Assert.AreEqual(60, instanceScoreManager.TotalScore);

            yield return null;

            //Passing many tile
            for (int i = 0; i < 11; i++)
            {
                instanceScoreManager.TilesCount(tile);
            }
            Assert.AreEqual(600, instanceScoreManager.DistanceScore);
            Assert.AreEqual(600, instanceScoreManager.TotalScore);

            //Destroy GameObjects
            Aloha.Utils.ClearCurrentScene();
        }
    }
}
