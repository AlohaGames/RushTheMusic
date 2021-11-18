using NUnit.Framework;
using UnityEngine;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// This class test the enemy mapping class functions.
    /// </summary>
    public class EnemyMappingTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        EnemyMapping[] GetEnemiesMapping()
        {
            EnemyMapping em0 = new EnemyMapping();

            Stats stats = new Stats();
            stats.Attack = 4;
            stats.Defense = 6;
            stats.Level = 1;
            stats.MaxHealth = 150;
            EnemyMapping em1 = new EnemyMapping(EnemyType.generic, stats, VerticalPositionEnum.TOP, HorizontalPositionEnum.RIGHT);

            EnemyMapping[] ems = { em0, em1 };
            return ems;
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void EnemyMappingConstructorTest()
        {
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(0, em0.Stats.Attack);
            Assert.AreEqual(0, em0.Stats.Defense);
            Assert.AreEqual(0, em0.Stats.Level);
            Assert.AreEqual(0, em0.Stats.MaxHealth);
            Assert.AreEqual(VerticalPositionEnum.BOT, em0.VerticalPosition);
            Assert.AreEqual(HorizontalPositionEnum.CENTER, em0.HorizontalPosition);

            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(4, em1.Stats.Attack);
            Assert.AreEqual(6, em1.Stats.Defense);
            Assert.AreEqual(1, em1.Stats.Level);
            Assert.AreEqual(150, em1.Stats.MaxHealth);
            Assert.AreEqual(VerticalPositionEnum.TOP, em1.VerticalPosition);
            Assert.AreEqual(HorizontalPositionEnum.RIGHT, em1.HorizontalPosition);
        }

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void EnemyMappingGetPositionTest()
        {
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(new Vector3(0, 1, 1), em0.GetPosition(1));

            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(new Vector3(1.5f, 3, 3), em1.GetPosition(3));
        }
    }
}
