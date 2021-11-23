using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{

    /// <summary>
    /// Object that represent a level read from an xml file
    /// </summary>
    public class LevelMapping
    {
        [SerializeField]
        public SerializeDictionary<int, List<EnemyMapping>> enemies;
        public int tileCount;
        public string biomeName;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LevelMapping()
        {
            this.enemies = new SerializeDictionary<int, List<EnemyMapping>>();
            this.tileCount = 0;
        }

        /// <summary>
        /// Constructor defining ennemies and number of tiles
        /// </summary>
        /// <param name="enemies">Dictionnary of enemies and the tile they appear on</param>
        /// <param name="tileCount">Number of tile, define the size (duratio) of the level</param>
        public LevelMapping(SerializeDictionary<int, List<EnemyMapping>> enemies, int tileCount)
        {
            this.enemies = enemies;
            this.tileCount = tileCount;
        }


        /// <summary>
        /// Get list of all enemy on a specific tile
        /// </summary>
        /// <param name="tileIndex">Index of the tile to get ennemies on</param>
        public List<EnemyMapping> GetEnnemies(int tileIndex)
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

        /// <summary>
        /// Get number of ennemies on the level
        /// </summary>
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
