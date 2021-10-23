using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Aloha
{
    public class LevelMapping
    {
        [SerializeField] public SerializeDictionary<int, List<EnemyMapping>> enemies;
        public int tileCount;

        public LevelMapping()
        {
            this.enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            this.tileCount = 0;
        }

        public LevelMapping(SerializeDictionary<int, List<EnemyMapping>> enemies, int tileCount)
        {
            this.enemies = enemies;
            this.tileCount = tileCount;

        }

        public List<EnemyMapping> getEnnemies(int tileIndex)
        {
            List<EnemyMapping> tileEnnemies = enemies.GetValue(tileIndex);
            if (tileEnnemies != null)
            {
                return tileEnnemies;
            }
            else
            {
                return new List<EnemyMapping>();
            }
        }

        public int GetEnemyNumber()
        {
            int enemiesnumber = 0;
            foreach (List<EnemyMapping> enemy in enemies.dictionaryValue)
            {
                enemiesnumber = enemiesnumber + enemy.Count;
            }
            return enemiesnumber;
        }
    }
}
