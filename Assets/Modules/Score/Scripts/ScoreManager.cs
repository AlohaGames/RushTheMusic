using Aloha.Events;
using System;
using UnityEngine;

namespace Aloha
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public const int DISTANCE_POINT = 60;
        public const int KILL_POINT = 30;
        public const int HIT_POINT = 10;
        public const int MAX_SCORE = 1000;
        public int TotalScore;
        private int _takeHitCounter;
        private int _killCounter;
        private int _tilesCounter;
        public int TakeHitCounter
        {
            get { return _takeHitCounter; }
        }
        public int KillCounter
        {
            get { return _killCounter; }
        }
        public int TilesCounter
        {
            get { return _tilesCounter; }
        }

        public void Awake()
        {
            GlobalEvent.HeroTakeDamage.AddListener(CountHeroHit);
            GlobalEvent.EntityDied.AddListener(DeathCount);
            GlobalEvent.TileCount.AddListener(TilesCount);
        }

        /// <summary>
        /// Counts the number of times the hero is hit
        /// </summary>
        public void CountHeroHit()
        {
            _takeHitCounter++;
            Debug.Log("Hero take " + _takeHitCounter + " hit");
            CalculateTotalScore();
        }

        /// <summary>
        /// Count the enemies killed
        /// </summary>
        public void DeathCount(Entity entity)
        {
            _killCounter++;
            Debug.Log("Kill: " + _killCounter);
            CalculateTotalScore();
        }

        public void TilesCount(GameObject tile)
        {
            _tilesCounter++;
            Debug.Log("Tiles number: " + _tilesCounter);
            CalculateTotalScore();
        }

        /// <summary>
        /// Total per level: 1000 points
        /// Distance score: 60%
        /// Enemy killed: 30%
        /// No hit: 10%
        /// </summary>
        public void CalculateTotalScore()
        {
            float scoreDistance = ScoreDistance();
            float scoreEnemyKilled = ScoreKill();
            float scoreHit = ScoreHit();
            Debug.Log("Distance : " + scoreDistance + "\nKill: " + scoreEnemyKilled + "\nHit: " + scoreHit);
            TotalScore = (int)(scoreDistance + scoreEnemyKilled - scoreHit);
        }

        /// <summary>
        /// Calculate score of no hit
        /// </summary>
        public float ScoreHit()
        {
            int maxHit = LevelManager.Instance.levelMapping != null ? LevelManager.Instance.levelMapping.GetEnemyNumber() / 2 : 0;
            Debug.Log("Hit: " + maxHit);
            if (maxHit > 0)
            {
                int heroTakeHit = Utils.InRangeInt(0, maxHit, _takeHitCounter);
                return CalculateScore(MAX_SCORE, HIT_POINT, (float)maxHit, heroTakeHit);
            }
            else if (maxHit == 0)
            {
                return 0f;
            }
            else
            {
                throw new IndexOutOfRangeException($"{maxHit} cannot be under 0");
            }

        }

        /// <summary>
        /// Calculate score of killing entity
        /// </summary>
        public float ScoreKill()
        {
            int maxEnemy = LevelManager.Instance.levelMapping != null ? LevelManager.Instance.levelMapping.GetEnemyNumber() : 0;
            Debug.Log("Enemy: " + maxEnemy);
            if (maxEnemy > 0)
            {
                int killEnemy = Utils.InRangeInt(0, maxEnemy, _killCounter);
                return CalculateScore(MAX_SCORE, KILL_POINT, (float)maxEnemy, killEnemy);
            }
            else if (maxEnemy == 0)
            {
                return 0f;
            }
            else
            {
                throw new IndexOutOfRangeException($"{maxEnemy} cannot be under 0");
            }
        }

        /// <summary>
        /// Calculate score of distance
        /// </summary>
        public float ScoreDistance()
        {
            int maxTiles = LevelManager.Instance.levelMapping != null ? LevelManager.Instance.levelMapping.tileCount : 0;
            Debug.Log("Tiles: " + maxTiles);
            if (maxTiles > 0)
            {
                int tiles = Utils.InRangeInt(0, maxTiles, _tilesCounter);
                return CalculateScore(MAX_SCORE, DISTANCE_POINT, (float)maxTiles, tiles);
            }
            else if (maxTiles == 0)
            {
                return 0f;
            }
            else
            {
                throw new IndexOutOfRangeException($"Max tiles: {maxTiles} cannot be under 0");
            }

        }

        /// <summary>
        /// Calculate total score
        /// </summary>
        public float CalculateScore(int maxScore, int percent, float maxStat, int stat)
        {
            float pourcentMaxScore = maxScore * (percent / 100f);
            float scoreStat = 1f - ((maxStat - stat) / maxStat);
            Debug.Log("Pourcent score: " + pourcentMaxScore);
            Debug.Log("Score stat: " + scoreStat);
            return pourcentMaxScore * scoreStat;
        }

        public void OnDestroy()
        {
            GlobalEvent.HeroTakeDamage.RemoveListener(CountHeroHit);
            GlobalEvent.EntityDied.RemoveListener(DeathCount);
            GlobalEvent.TileCount.RemoveListener(TilesCount);
        }
    }
}