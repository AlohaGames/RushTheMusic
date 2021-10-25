using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Aloha.Test
{
    public class LevelMappingTest
    {

        LevelMapping[] GetLevelsMapping()
        {
            LevelMapping lm0 = new LevelMapping();
            LevelMapping lm1 = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(), 180);

            // Create tile 10 enemies
            EnemyMapping em0 = new EnemyMapping();
            List<EnemyMapping> enemiesMapping = new List<EnemyMapping>();
            enemiesMapping.Add(em0);

            // Enemy on tile 10
            List<int> keys = new List<int>();
            keys.Add(10);

            // Create enemies
            List<List<EnemyMapping>> enemies = new List<List<EnemyMapping>>();
            enemies.Add(enemiesMapping);

            LevelMapping lm2 = new LevelMapping(new SerializeDictionary<int, List<EnemyMapping>>(keys, enemies), 180);

            LevelMapping[] lms = { lm0, lm1, lm2 };
            return lms;
        }

        [Test]
        public void LevelMappingConstructorTest()
        {
            LevelMapping lm0 = GetLevelsMapping()[0];
            Assert.AreEqual(0, lm0.tileCount);

            LevelMapping lm1 = GetLevelsMapping()[1];
            Assert.AreEqual(180, lm1.tileCount);
        }

        [Test]
        public void LevelMappingGetEnemiesTest()
        {
            LevelMapping lm0 = GetLevelsMapping()[0];
            Assert.AreEqual(0, lm0.getEnnemies(10).Count);

            LevelMapping lm2 = GetLevelsMapping()[2];
            Assert.AreEqual(1, lm2.getEnnemies(10).Count);
        }
    }
}
