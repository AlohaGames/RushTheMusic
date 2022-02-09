using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public enum VerticalPositionEnum
    {
        TOP = 0, MIDDLE = 1, BOT = 2
    }

    public enum HorizontalPositionEnum
    {
        LEFT = 0, CENTER = 1, RIGHT = 2
    }

    /// <summary>
    /// Class for mapping of ennemies
    /// </summary>
    public class EnemyMapping
    {
        public EnemyType EnemyType;
        public Stats Stats; //TODO Remove safely after modifying map
        public VerticalPositionEnum VerticalPosition;
        public HorizontalPositionEnum HorizontalPosition;

        public List<string> Parameters = new List<string>();

        /// <summary>
        /// Default constructor of enemyMapping
        /// <example> Example(s):
        /// <code>
        ///     EnemyMapping em0 = new EnemyMapping();
        /// </code>
        /// </example>
        /// </summary>
        public EnemyMapping() : this(EnemyType.generic, VerticalPositionEnum.BOT, HorizontalPositionEnum.CENTER) { }

        /// <summary>
        /// Default constructor with parameters
        /// <example> Example(s):
        /// <code>
        ///     EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, VerticalPositionEnum.BOT, HorizontalPositionEnum.CENTER, new List<string>());
        /// </code>
        /// </example>
        /// </summary>
        public EnemyMapping(EnemyType enemyType, VerticalPositionEnum verticalPosition, HorizontalPositionEnum horizontalPosition, List<string> parameters = null)
        {
            this.EnemyType = enemyType;
            this.VerticalPosition = verticalPosition;
            this.HorizontalPosition = horizontalPosition;
            this.Parameters = parameters ?? new List<string>();
        }

        /// <summary>
        /// Gives enemy position for a specific Z
        /// <example> Example(s):
        /// <code>
        ///     enemy.transform.position = enemyMapping.GetPosition(tile.transform.position.z);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="z"></param>
        /// <returns>
        ///     Position of the enemy
        /// </returns>
        public Vector3 GetPosition(float z)
        {
            float x = 0;
            float y = 0;

            switch (this.VerticalPosition)
            {
                case VerticalPositionEnum.TOP:
                    y = 2f;
                    break;
                case VerticalPositionEnum.MIDDLE:
                    y = 1f;
                    break;
                case VerticalPositionEnum.BOT:
                    y = 0f;
                    break;
            }

            switch (this.HorizontalPosition)
            {
                case HorizontalPositionEnum.LEFT:
                    x = -1.5f;
                    break;
                case HorizontalPositionEnum.CENTER:
                    x = 0f;
                    break;
                case HorizontalPositionEnum.RIGHT:
                    x = 1.5f;
                    break;
            }

            return new Vector3(x, y + 1, z);
        }

        /// <summary>
        /// Add Parameters to an EnemyMapping, only one value for one type
        /// </summary>
        /// <param name="type">Type of parameters (Item for Chest)</param>
        /// <param name="parameter">Value of the parameters</param>
        public void AddParameters(string type, string parameter)
        {
            string p = this.Parameters.Find((s) =>
            {
                return s.StartsWith(type);
            });
            if (p != null)
            {
                Parameters.Remove(p);
            }
            this.Parameters.Add(type + " : " + parameter);
        }
    }
}
