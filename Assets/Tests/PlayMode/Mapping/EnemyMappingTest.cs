using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Aloha.EntityStats;

namespace Aloha.Test
{
    public class EnemyMappingTest
    {
        public EnemyMapping[] GetEnemiesMapping()
        {
            EnemyMapping em0 = new EnemyMapping();

            Stats stats = new Stats();
            stats.attack = 4;
            stats.defense = 6;
            stats.level = 1;
            stats.maxHealth = 150;
            EnemyMapping em1 = new EnemyMapping(EnemyType.generic, stats, VerticalPosition.TOP, HorizontalPosition.RIGHT);

            EnemyMapping[] ems = { em0, em1 };
            return ems;
        }

        [Test]
        public void EnemyMappingConstructorTest()
        {
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(0, em0.stats.attack);
            Assert.AreEqual(0, em0.stats.defense);
            Assert.AreEqual(0, em0.stats.level);
            Assert.AreEqual(0, em0.stats.maxHealth);
            Assert.AreEqual(VerticalPosition.BOT, em0.verticalPosition);
            Assert.AreEqual(HorizontalPosition.CENTER, em0.horizontalPosition);

            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(4, em1.stats.attack);
            Assert.AreEqual(6, em1.stats.defense);
            Assert.AreEqual(1, em1.stats.level);
            Assert.AreEqual(150, em1.stats.maxHealth);
            Assert.AreEqual(VerticalPosition.TOP, em1.verticalPosition);
            Assert.AreEqual(HorizontalPosition.RIGHT, em1.horizontalPosition);
        }

        [Test]
        public void EnemyMappingGetPosition()
        {
            EnemyMapping em0 = GetEnemiesMapping()[0];
            Assert.AreEqual(new Vector3(0, 1, 1), em0.GetPosition(1));

            EnemyMapping em1 = GetEnemiesMapping()[1];
            Assert.AreEqual(new Vector3(1.5f, 3, 3), em1.GetPosition(3));
        }
    }
}
