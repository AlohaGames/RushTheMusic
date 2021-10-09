using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    public class EnemyMapping
    {
        [SerializeField] public EnemyType enemyType;
        [SerializeField] public Stats stats;
        [SerializeField] public VerticalPosition verticalPosition;
        [SerializeField] public HorizontalPosition horizontalPosition;

        public EnemyMapping() : this(EnemyType.generic, null, 0, 0) { }

        public EnemyMapping(EnemyType enemyType, Stats stats, VerticalPosition verticalPosition, HorizontalPosition horizontalPosition)
        {
            this.enemyType = enemyType;
            this.verticalPosition = verticalPosition;
            this.horizontalPosition = horizontalPosition;
            // TODO: If no stats, generate them
            this.stats = stats;
        }
    }

    public enum VerticalPosition
    {
        TOP = 0, MIDDLE = 1, BOT = 2
    }

    public enum HorizontalPosition
    {
        LEFT = 0, CENTER = 1, RIGHT = 2
    }
}
