using System;
using UnityEngine;

namespace Aloha.EntityStats
{
    /// <summary>
    /// Stats for chest
    /// </summary>
    [CreateAssetMenu(fileName = "ChestStats", menuName = "Stats/Enemy/Chest", order = 1)]
    public class ChestStats : EnemyStats 
    {
        public ItemType Item;
    }
}
