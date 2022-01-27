using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    public class EnemyTypeToSprite : Singleton<EnemyTypeToSprite>
    {
        public Sprite Default;
        public Sprite Lancer;
        public Sprite Wyrmling;
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
        /// <returns></returns>

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
                // case EnemyType.spider:
                // return Spider;
                case EnemyType.darkWizard:
                    return DarkWizard;
                default:
                    return Default;
            }
        }
    }
}
