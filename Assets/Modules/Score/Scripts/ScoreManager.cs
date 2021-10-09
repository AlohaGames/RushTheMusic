using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public int totalScore;

        [SerializeField]
        private int takeHit;

        [SerializeField]
        private int killCount;

        [SerializeField]
        private int countTiles;
        private int maxScore = 1000;
        private int maxEnemy = 10;
        private int maxHit;
        private int maxTiles = 20;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        public void Awake()
        {
            GlobalEvent.HeroTakeDamage.AddListener(CountHeroHit);
            GlobalEvent.EntityDied.AddListener(DeathCount);

            this.maxHit = this.maxEnemy / 2;
        }

        /// <summary>
        /// Counts the number of times the hero is hit
        /// </summary>
        public void CountHeroHit()
        {
            takeHit++;
            Debug.Log("Hero take " + takeHit + " hit");
        }

        /// <summary>
        /// Count the enemies killed
        /// </summary>
        public void DeathCount(Entity entity)
        {
            killCount++;
            Debug.Log("Kill: " + killCount);
        }

        /// <summary>
        /// Total per level: 1000 points
        /// Distance score: 60%
        /// Enemy killed: 30%
        /// No hit: 10%
        /// </summary>
        public int CalculateTotalScore()
        {
            int killEnemy = Utils.InRangeInt(0, this.maxEnemy, this.killCount);
            int heroTakeHit = Utils.InRangeInt(0, this.maxHit, this.takeHit);
            float scoreDistance = 600f;
            float scoreEnemyKilled = CalculateScore(this.maxScore, 30, (float) this.maxEnemy, killEnemy);
            float scoreHit = CalculateScore(this.maxScore, 10, (float) this.maxHit, heroTakeHit);
            return this.totalScore = (int)(scoreDistance + scoreEnemyKilled - scoreHit);
        }

        private float CalculateScore(int maxScore, int percent, float maxStat, int stat)
        {
            float pourcentMaxScore = maxScore * (percent / 100f);
            float scoreStat = 1f - ((maxStat - stat) / maxStat);
            Debug.Log("Score stat: " + scoreStat);
            return pourcentMaxScore * scoreStat;
        }

        /// <summary>
        /// Destroy the listeners
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.HeroTakeDamage.RemoveListener(CountHeroHit);
            GlobalEvent.EntityDied.RemoveListener(DeathCount);
        }
    }
}