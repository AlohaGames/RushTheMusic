using System;
using UnityEngine;

namespace Aloha.EntityStats
{
    /// <summary>
    /// Stats for Canon
    /// </summary>
    [CreateAssetMenu(fileName = "CanonStats", menuName = "Stats/Enemy/Canon", order = 1)]
    public class CanonStats : EnemyStats
    {
        public ItemType Item;
    }
}
