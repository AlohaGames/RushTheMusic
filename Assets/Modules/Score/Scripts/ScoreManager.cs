using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public const int DISTANCE_POINT = 60;
        public const int KILL_POINT = 30;
        public const int HIT_POINT = 10;
        public const int MAX_SCORE = 1000;
        public int totalScore;
        [SerializeField]
        private int takeHitCounter;
        [SerializeField]
        private int killCounter;
        [SerializeField]
        private int tilesCounter;
        private int maxEnemy;
        private int maxHit;
        private int maxTiles;

        public int GetTakeHit()
        {
            return this.takeHitCounter;
        }

        public int GetKillCount()
        {
            return this.killCounter;
        }

        public int GetTilesCount()
        {
            return this.tilesCounter;
        }

        public void Awake()
        {
            GlobalEvent.HeroTakeDamage.AddListener(CountHeroHit);
            GlobalEvent.EntityDied.AddListener(DeathCount);
            GlobalEvent.TileCount.AddListener(TilesCount);

            this.maxHit = this.maxEnemy / 2;
            this.maxTiles = LevelManager.Instance.levelMapping.tileCount;
            this.maxEnemy = LevelManager.Instance.levelMapping.GetEnemyNumber();
        }

        /// <summary>
        /// Counts the number of times the hero is hit
        /// </summary>
        public void CountHeroHit()
        {
            takeHitCounter++;
            Debug.Log("Hero take " + takeHitCounter + " hit");
        }

        /// <summary>
        /// Count the enemies killed
        /// </summary>
        public void DeathCount(Entity entity)
        {
            killCounter++;
            Debug.Log("Kill: " + killCounter);
        }

        public void TilesCount(GameObject tile)
        {
            tilesCounter++;
            Debug.Log("Tiles number: " + tilesCounter);
        }

        /// <summary>
        /// Total per level: 1000 points
        /// Distance score: 60%
        /// Enemy killed: 30%
        /// No hit: 10%
        /// </summary>
        public int CalculateTotalScore()
        {
            float scoreDistance = ScoreDistance();
            float scoreEnemyKilled = ScoreKill();
            float scoreHit = ScoreHit();
            return this.totalScore = (int)(scoreDistance + scoreEnemyKilled - scoreHit);
        }

        /// <summary>
        /// Calculate score of no hit
        /// </summary>
        public float ScoreHit()
        {
            int heroTakeHit = Utils.InRangeInt(0, this.maxHit, this.takeHitCounter);
            return CalculateScore(MAX_SCORE, HIT_POINT, (float)this.maxHit, heroTakeHit);
        }

        /// <summary>
        /// Calculate score of killing entity
        /// </summary>
        public float ScoreKill()
        {
            int killEnemy = Utils.InRangeInt(0, this.maxEnemy, this.killCounter);
            return CalculateScore(MAX_SCORE, KILL_POINT, (float)this.maxEnemy, killEnemy);
        }

        /// <summary>
        /// Calculate score of distance
        /// </summary>
        public float ScoreDistance()
        {
            int tiles = Utils.InRangeInt(0, this.maxTiles, this.tilesCounter);
            return CalculateScore(MAX_SCORE, DISTANCE_POINT, (float)this.maxTiles, tiles);
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