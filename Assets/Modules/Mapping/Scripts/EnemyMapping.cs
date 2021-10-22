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

        public EnemyMapping()
        {
            Stats stats = new Stats();
            stats.attack = 0;
            stats.defense = 0;
            stats.level = 0;
            stats.maxHealth = 0;
            VerticalPosition vpos = VerticalPosition.BOT;
            HorizontalPosition hpos = HorizontalPosition.CENTER;
            Initialize(EnemyType.generic, stats, vpos, hpos);
        }

        public EnemyMapping(EnemyType enemyType, Stats stats, VerticalPosition verticalPosition, HorizontalPosition horizontalPosition)
        {
            Initialize(enemyType, stats, verticalPosition, horizontalPosition);
        }

        public void Initialize(EnemyType enemyType, Stats stats, VerticalPosition verticalPosition, HorizontalPosition horizontalPosition)
        {
            this.enemyType = enemyType;
            this.verticalPosition = verticalPosition;
            this.horizontalPosition = horizontalPosition;
            this.stats = stats;
        }

        public Vector3 GetPosition(float z)
        {
            float x = 0;
            float y = 0;

            switch (this.verticalPosition)
            {
                case VerticalPosition.TOP:
                    y = 2f;
                    break;
                case VerticalPosition.MIDDLE:
                    y = 1f;
                    break;
                case VerticalPosition.BOT:
                    y = 0f;
                    break;
            }

            switch (this.horizontalPosition)
            {
                case HorizontalPosition.LEFT:
                    x = -1.5f;
                    break;
                case HorizontalPosition.CENTER:
                    x = 0f;
                    break;
                case HorizontalPosition.RIGHT:
                    x = 1.5f;
                    break;
            }

            return new Vector3(x, y + 1, z);
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
