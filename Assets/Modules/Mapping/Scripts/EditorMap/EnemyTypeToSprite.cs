using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Enemy Type to Sprite
    /// </summary>
    public class EnemyTypeToSprite : Singleton<EnemyTypeToSprite>
    {
        public Sprite Default;
        public Sprite Lancer;
        public Sprite IceLancer;
        public Sprite FireLancer;
        public Sprite Wyrmling;
        public Sprite FireWyrmling;
        public Sprite IceWyrmling;
        public Sprite Assassin;
        public Sprite Chest;
        public Sprite Wall;
        public Sprite Spider;
        public Sprite Canon;
        public Sprite Bat;
        public Sprite DarkWizard;

        public Sprite Delete;

        /// <summary>
        /// Get the corresponding Enemy Sprite based on EnemyType
        /// </summary>
        /// <param name="enemyType"></param>
        /// <returns>Corresponding Sprite if EnemyType is define, default otherwise</returns>

        public Sprite GetEnemySprite(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.lancer:
                    return Lancer;
                case EnemyType.wyrmling:
                    return Wyrmling;
                case EnemyType.assassin:
                    return Assassin;
                case EnemyType.chest:
                    return Chest;
                case EnemyType.wall:
                    return Wall;
                case EnemyType.canon:
                    return Canon;
                case EnemyType.bat:
                    return Bat;
                case EnemyType.darkWizard:
                    return DarkWizard;
                case EnemyType.iceLancer:
                    return IceLancer;
                case EnemyType.fireLancer:
                    return FireLancer;
                case EnemyType.fireWyrmling:
                    return FireWyrmling;
                case EnemyType.iceWyrmling:
                    return IceWyrmling;
                default:
                    return Default;
            }
        }
    }
}
