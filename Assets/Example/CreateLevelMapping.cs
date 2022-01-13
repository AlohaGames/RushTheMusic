using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class CreateLevelMapping : MonoBehaviour
    {
        public void CreateAndSave()
        {
            EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, VerticalPositionEnum.BOT, HorizontalPositionEnum.CENTER, new List<string>());

            List<EnemyMapping> tile10Enemies = new List<EnemyMapping>();
            tile10Enemies.Add(genericEnemy);

            SerializeDictionary<int, List<EnemyMapping>> enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            enemies.Add(10, tile10Enemies);

            LevelMapping levelMapping = new LevelMapping(enemies, 80);

            // Save le level
            // TODO réparer
            // LevelManager.Instance.Save(levelMapping, "Example", true);

            // Reset
            levelMapping = null;
        }
    }
}
