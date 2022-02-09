using NUnit.Framework;
using UnityEngine;

namespace Aloha.Test
{
    /// <summary>
    /// This class test the enemy mapping class functions.
    /// </summary>
    public class EnemyMappingTest
    {
        /// <summary>
        /// Create an array of enemy mapping
        /// </summary>
        EnemyMapping[] GetEnemiesMapping()
        {
            EnemyMapping em0 = new EnemyMapping();

            Stats stats = ScriptableObject.CreateInstance<Stats>();
            stats.Attack = 4;
            stats.Defense = 6;
            stats.Level = 1;
            stats.MaxHealth = 150;
            EnemyMapping em1 = new EnemyMapping(EnemyType.generic, VerticalPositionEnum.TOP, HorizontalPositionEnum.RIGHT);

            EnemyMapping[] ems = { em0, em1 };
            return ems;
        }

        /// <summary>
        /// Check if enemy mapping constructor works
        /// </summary>
        [Test]
        public void EnemyMappingConstructorTest()
        {
            // Position of the first enemy
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(VerticalPositionEnum.BOT, em0.VerticalPosition);
            Assert.AreEqual(HorizontalPositionEnum.CENTER, em0.HorizontalPosition);

            // Position of the second enemy 
            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(VerticalPositionEnum.TOP, em1.VerticalPosition);
            Assert.AreEqual(HorizontalPositionEnum.RIGHT, em1.HorizontalPosition);


            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        /// <summary>
        /// Check if position functions works with enemy mapping
        /// </summary>
        [Test]
        public void EnemyMappingGetPositionTest()
        {
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(new Vector3(0, 1, 1), em0.GetPosition(1));

            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(new Vector3(1.5f, 3, 3), em1.GetPosition(3));

            // Clear the scene
            Utils.ClearCurrentScene(true);

        }
    }
}
