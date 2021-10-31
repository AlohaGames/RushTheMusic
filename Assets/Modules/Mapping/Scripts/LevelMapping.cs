using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class LevelMapping
    {
        public SerializeDictionary<int, List<EnemyMapping>> Enemies;
        public int TileCount;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        public LevelMapping()
        {
            this.Enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            this.TileCount = 0;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="enemies"></param>
        /// <param name="tileCount"></param>
        public LevelMapping(SerializeDictionary<int, List<EnemyMapping>> enemies, int tileCount)
        {
            this.Enemies = enemies;
            this.TileCount = tileCount;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public List<EnemyMapping> GetEnnemies(int tileIndex)
        {
            List<EnemyMapping> tileEnnemies = Enemies.GetValue(tileIndex);
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
            foreach (List<EnemyMapping> enemy in Enemies.DictionaryValue)
            {
                enemiesnumber = enemiesnumber + enemy.Count;
            }
            return enemiesnumber;
        }
    }
}
