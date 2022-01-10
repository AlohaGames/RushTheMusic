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
        public Stats Stats;
        public VerticalPositionEnum VerticalPosition;
        public HorizontalPositionEnum HorizontalPosition;

        /// <summary>
        /// Default constructor of enemyMapping
        /// <example> Example(s):
        /// <code>
        ///     EnemyMapping em0 = new EnemyMapping();
        /// </code>
        /// </example>
        /// </summary>
        public EnemyMapping()
        {
            Stats stats = ScriptableObject.CreateInstance<Stats>();
            stats.Attack = 10;
            stats.Defense = 0;
            stats.Level = 0;
            stats.MaxHealth = 1;
            VerticalPositionEnum vpos = VerticalPositionEnum.BOT;
            HorizontalPositionEnum hpos = HorizontalPositionEnum.CENTER;
            Initialize(EnemyType.generic, stats, vpos, hpos);
        }

        /// <summary>
        /// Default constructor with parameters
        /// <example> Example(s):
        /// <code>
        ///     EnemyMapping genericEnemy = new EnemyMapping(EnemyType.generic, enemyStats, VerticalPositionEnum.BOT, HorizontalPositionEnum.CENTER);
        /// </code>
        /// </example>
        /// </summary>
        public EnemyMapping(EnemyType enemyType, Stats stats, VerticalPositionEnum verticalPosition, HorizontalPositionEnum horizontalPosition)
        {
            Initialize(enemyType, stats, verticalPosition, horizontalPosition);
        }

        /// <summary>
        /// Initialise enemy informations
        /// <example> Example(s):
        /// <code>
        /// this.Initialize(EnemyType.generic, stats, vpos, hpos);
        /// </code>
        /// </example>
        /// </summary>
        public void Initialize(EnemyType enemyType, Stats stats, VerticalPositionEnum verticalPosition, HorizontalPositionEnum horizontalPosition)
        {
            this.EnemyType = enemyType;
            this.VerticalPosition = verticalPosition;
            this.HorizontalPosition = horizontalPosition;
            this.Stats = stats;
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
    }
}
