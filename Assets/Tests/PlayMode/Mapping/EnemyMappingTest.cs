using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Aloha.Test
{
    public class EnemyMappingTest
    {
        EnemyMapping[] GetEnemiesMapping()
        {
            EnemyMapping em0 = new EnemyMapping();

            Stats stats = new Stats();
            stats.Attack = 4;
            stats.Defense = 6;
            stats.Level = 1;
            stats.MaxHealth = 150;
            EnemyMapping em1 = new EnemyMapping(EnemyType.generic, stats, VerticalPosition.TOP, HorizontalPosition.RIGHT);

            EnemyMapping[] ems = { em0, em1 };
            return ems;
        }

        [Test]
        public void EnemyMappingConstructorTest()
        {
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(0, em0.stats.Attack);
            Assert.AreEqual(0, em0.stats.Defense);
            Assert.AreEqual(0, em0.stats.Level);
            Assert.AreEqual(0, em0.stats.MaxHealth);
            Assert.AreEqual(VerticalPosition.BOT, em0.verticalPosition);
            Assert.AreEqual(HorizontalPosition.CENTER, em0.horizontalPosition);

            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(4, em1.stats.Attack);
            Assert.AreEqual(6, em1.stats.Defense);
            Assert.AreEqual(1, em1.stats.Level);
            Assert.AreEqual(150, em1.stats.MaxHealth);
            Assert.AreEqual(VerticalPosition.TOP, em1.verticalPosition);
            Assert.AreEqual(HorizontalPosition.RIGHT, em1.horizontalPosition);
        }

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
