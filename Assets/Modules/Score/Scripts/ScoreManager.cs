using Aloha.Events;
using System;
using UnityEngine;

namespace Aloha
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public const int DISTANCE_PERCENT = 60;
        public const int KILL_PERCENT = 30;
        public const int HIT_PERCENT = 10;
        public const int MAX_SCORE = 1000;
        public int TotalScore;
        public int DistanceScore;
        public int EnemyKilledScore;
        public int HitScore;
        public int TakeHitCounter
        {
            get;
            private set;
        }
        public int KillCounter;
        public int TilesCounter;
        public UIScore ScoreUI;

        public void Awake()
        {
            GlobalEvent.HeroTakeDamage.AddListener(CountHeroHit);
            GlobalEvent.EntityDied.AddListener(DeathCount);
            GlobalEvent.TileCount.AddListener(TilesCount);
            //GlobalEvent.OnInGameScoreUpdate.AddListener(CalculateTotalScore);
        }

        /// <summary>
        /// Counts the number of times the hero is hit
        /// </summary>
        public void CountHeroHit()
        {
            TakeHitCounter++;
            ScoreHit();
        }

        /// <summary>
        /// Count the enemies killed
        /// </summary>
        public void DeathCount(Entity entity)
        {
            KillCounter++;
            ScoreKill();
        }

        public void TilesCount(GameObject tile)
        {
            TilesCounter++;
            ScoreDistance();
        }

        /// <summary>
        /// Total per level: 1000 points
        /// Distance score: 60%
        /// Enemy killed: 30%
        /// No hit: 10%
        /// </summary>
        public void CalculateTotalScore()
        {
            TotalScore = (DistanceScore + EnemyKilledScore - HitScore);
            ScoreUI?.UpdateUIText();
        }

        /// <summary>
        /// Calculate score of no hit
        /// </summary>
        public void ScoreHit()
        {
            int maxHit = LevelManager.Instance.levelMapping != null ? LevelManager.Instance.levelMapping.GetEnemyNumber() / 2 : 0;
            if (maxHit > 0)
            {
                int heroTakeHit = TakeHitCounter.InRange(0, maxHit);
                HitScore = (int) CalculateScore(MAX_SCORE, HIT_PERCENT, (float)maxHit, heroTakeHit);
            }
            else if (maxHit == 0)
            {
                HitScore = 0;
            }
            CalculateTotalScore();

        }

        /// <summary>
        /// Calculate score of killing entity
        /// </summary>
        public void ScoreKill()
        {
            int maxEnemy = LevelManager.Instance.levelMapping != null ? LevelManager.Instance.levelMapping.GetEnemyNumber() : 0;
            if (maxEnemy > 0)
            {
                int killEnemy = KillCounter.InRange(0, maxEnemy);
                EnemyKilledScore = (int) CalculateScore(MAX_SCORE, KILL_PERCENT, (float)maxEnemy, killEnemy);
            }
            else if (maxEnemy == 0)
            {
                EnemyKilledScore = 0;
            }
            CalculateTotalScore();
        }

        /// <summary>
        /// Calculate score of distance
        /// </summary>
        public void ScoreDistance()
        {
            int maxTiles = LevelManager.Instance.levelMapping != null ? LevelManager.Instance.levelMapping.tileCount : 0;
            if (maxTiles > 0)
            {
                int tiles = TilesCounter.InRange(0, maxTiles);
                DistanceScore = (int) CalculateScore(MAX_SCORE, DISTANCE_PERCENT, (float)maxTiles, tiles);
            }
            else if (maxTiles == 0)
            {
                DistanceScore = 0;
            }
            CalculateTotalScore();
        }

        /// <summary>
        /// Calculate total score
        /// </summary>
        public float CalculateScore(int maxScore, int percent, float maxStat, int stat)
        {
            float pourcentMaxScore = maxScore * (percent / 100f);
            float scoreStat = 1f - ((maxStat - stat) / maxStat);
            return pourcentMaxScore * scoreStat;
        }

        public void OnDestroy()
        {
            GlobalEvent.HeroTakeDamage.RemoveListener(CountHeroHit);
            GlobalEvent.EntityDied.RemoveListener(DeathCount);
            GlobalEvent.TileCount.RemoveListener(TilesCount);
            //GlobalEvent.OnInGameScoreUpdate.RemoveListener(CalculateTotalScore);
        }
    }
}