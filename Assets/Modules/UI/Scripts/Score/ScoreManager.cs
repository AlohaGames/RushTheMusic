using Aloha.Events;
using System;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the score
    /// </summary>
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

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
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

        /// <summary>
        /// Count the tiles passed
        /// </summary>
        public void TilesCount(GameObject tile)
        {
            TilesCounter++;
            ScoreDistance();
        }

        /// <summary>
        /// This function calculate total score according to distance score (60%), enemy killed score (30%) and hit taken (10%).
        /// <example> Example(s):
        /// <code>
        ///     CalculateTotalScore();
        /// </code>
        /// </example>
        /// </summary>
        public void CalculateTotalScore()
        {
            TotalScore = (DistanceScore + EnemyKilledScore - HitScore);
            ScoreUI?.UpdateUIText();
        }

        /// <summary>
        /// This function calculate the hit score.
        /// <example> Example(s):
        /// <code>
        ///     ScoreHit();
        /// </code>
        /// </example>
        /// </summary>
        public void ScoreHit()
        {
            int maxHit = LevelManager.Instance.LevelMapping != null ? LevelManager.Instance.LevelMapping.GetEnemyNumber() / 2 : 0;
            if (maxHit > 0)
            {
                int heroTakeHit = TakeHitCounter.Clamp(0, maxHit);
                HitScore = (int) CalculateScore(MAX_SCORE, HIT_PERCENT, (float)maxHit, heroTakeHit);
            }
            else if (maxHit == 0)
            {
                HitScore = 0;
            }
            CalculateTotalScore();

        }

        /// <summary>
        /// This function calculate the kill score.
        /// <example> Example(s):
        /// <code>
        ///     ScoreKill();
        /// </code>
        /// </example>
        /// </summary>
        public void ScoreKill()
        {
            int maxEnemy = LevelManager.Instance.LevelMapping != null ? LevelManager.Instance.LevelMapping.GetEnemyNumber() : 0;
            if (maxEnemy > 0)
            {
                int killEnemy = KillCounter.Clamp(0, maxEnemy);
                EnemyKilledScore = (int) CalculateScore(MAX_SCORE, KILL_PERCENT, (float)maxEnemy, killEnemy);
            }
            else if (maxEnemy == 0)
            {
                EnemyKilledScore = 0;
            }
            CalculateTotalScore();
        }

        /// <summary>
        /// This function calculate the distance score.
        /// <example> Example(s):
        /// <code>
        ///     ScoreDistance();
        /// </code>
        /// </example>
        /// </summary>
        public void ScoreDistance()
        {
            int maxTiles = LevelManager.Instance.LevelMapping != null ? LevelManager.Instance.LevelMapping.TileCount : 0;
            if (maxTiles > 0)
            {
                int tiles = TilesCounter.Clamp(0, maxTiles);
                DistanceScore = (int) CalculateScore(MAX_SCORE, DISTANCE_PERCENT, (float)maxTiles, tiles);
            }
            else if (maxTiles == 0)
            {
                DistanceScore = 0;
            }
            CalculateTotalScore();
        }

        /// <summary>
        /// This function calculate the score according to a maximum score, a percent, a maximum stat and a actual stat.
        /// <example> Example(s):
        /// <code>
        ///     float a = CalculateScore();
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="maxScore"></param>
        /// <param name="percent"></param>
        /// <param name="maxStat"></param>
        /// <param name="stats"></param>
        /// <returns>
        /// A score float.
        /// </returns>
        public float CalculateScore(int maxScore, int percent, float maxStat, int stat)
        {
            float pourcentMaxScore = maxScore * (percent / 100f);
            float scoreStat = 1f - ((maxStat - stat) / maxStat);
            return pourcentMaxScore * scoreStat;
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.HeroTakeDamage.RemoveListener(CountHeroHit);
            GlobalEvent.EntityDied.RemoveListener(DeathCount);
            GlobalEvent.TileCount.RemoveListener(TilesCount);
        }
    }
}