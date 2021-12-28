using NUnit.Framework;
using System.Collections.Generic;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// This class test the level mapping class functions.
    /// </summary>
    public class LevelMappingTest
    {

        /// <summary>
        /// TODO @Tristan
        /// </summary>
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

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void LevelMappingConstructorTest()
        {
            LevelMapping lm0 = GetLevelsMapping()[0];
            Assert.AreEqual(0, lm0.TileCount);

            LevelMapping lm1 = GetLevelsMapping()[1];
            Assert.AreEqual(180, lm1.TileCount);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void LevelMappingGetEnemiesTest()
        {
            LevelMapping lm0 = GetLevelsMapping()[0];
            Assert.AreEqual(0, lm0.GetEnnemies(10).Count);

            LevelMapping lm2 = GetLevelsMapping()[2];
            Assert.AreEqual(1, lm2.GetEnnemies(10).Count);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }
    }
}
