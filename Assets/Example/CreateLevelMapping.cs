using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class CreateLevelMapping : MonoBehaviour
    {
        public void CreateAndSave()
        {
            Stats enemyStats = ScriptableObject.CreateInstance<Stats>();
            enemyStats.Attack = 10;
            enemyStats.Defense = 10;
            enemyStats.MaxHealth = 10;
            enemyStats.Level = 2;

            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPositionEnum.BOT, HorizontalPositionEnum.CENTER);

            List<EnemyMapping> tile10Enemies = new List<EnemyMapping>();
            tile10Enemies.Add(genericEnemy);

            SerializeDictionary<int, List<EnemyMapping>> enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            enemies.Add(10, tile10Enemies);

            LevelMapping levelMapping = new LevelMapping(enemies, 80);

            // Save le level
            LevelManager.Instance.Save(levelMapping, "Example", true);

            // Reset
            levelMapping = null;
        }
    }
}
