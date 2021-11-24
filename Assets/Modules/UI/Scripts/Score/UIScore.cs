using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class UIScore : MonoBehaviour
    {
        public GameObject EndGameScore;
        public GameObject ScoreDetail;
        public GameObject InGameScore;
        public Text InGameScoreText;
        public Text TotalScoreText;
        public Text DistanceScoreText;
        public Text KillScoreText;
        public Text HitScoreText;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void ShowInGameUIScoreElements()
        {
            InGameScore.SetActive(true);
            UpdateUIText();
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void UpdateUIText()
        {
            InGameScoreText.text = "Score: " + ScoreManager.Instance.TotalScore;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void ShowEndGameUIScoreElements()
        {
            EndGameScore.SetActive(true);
            TotalScoreText.text = "Score total: " + ScoreManager.Instance.TotalScore;
            DistanceScoreText.text = "Distance\t" + ScoreManager.Instance.DistanceScore;
            KillScoreText.text = "Ennemis tués\t" + ScoreManager.Instance.EnemyKilledScore;
            HitScoreText.text = "Coups reçus\t" + ScoreManager.Instance.HitScore;
            GameManager.Instance.IsPlaying = false;
        }
    }
}
