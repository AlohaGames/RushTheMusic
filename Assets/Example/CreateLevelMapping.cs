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
            enemyStats.attack = 10;
            enemyStats.defense = 10;
            enemyStats.maxHealth = 10;
            enemyStats.level = 2;

            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPosition.BOT, HorizontalPosition.CENTER);

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
