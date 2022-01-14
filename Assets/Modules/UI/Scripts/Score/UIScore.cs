using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Class for the score UI
    /// </summary>
    public class UIScore : MonoBehaviour
    {
        public GameObject EndGameScore;
        public GameObject ScoreDetail;
        public GameObject InGameScore;
        public Text InGameScoreText;
        public Text InGameScoreInfini;
        public Text TotalScoreText;
        public Text DistanceScoreText;
        public Text KillScoreText;
        public Text HitScoreText;

        /// <summary>
        /// Method to show UI score elements in game
        /// <example> Example(s):
        /// <code>
        ///     UIScore.ShowInGameUIScoreElements();
        /// </code>
        /// </example>
        /// </summary>
        public void ShowInGameUIScoreElements()
        {
            InGameScore.SetActive(true);

            // Show total score if inifinite mode is ONE
            if (GameManager.Instance.IsInfinite)
            {
                InGameScoreInfini.gameObject.SetActive(true);
            }
            else
            {
                InGameScoreInfini.gameObject.SetActive(false);
            }

            UpdateUIText();
        }

        /// <summary>
        /// Update text of the score UI text
        /// <example> Example(s):
        /// <code>
        ///     ScoreUI?.UpdateUIText();
        /// </code>
        /// </example>
        /// </summary>
        public void UpdateUIText()
        {
            InGameScoreText.text = "Score: " + ScoreManager.Instance.TotalScore;
            InGameScoreInfini.text = "(Total: " + ScoreManager.Instance.InfiniteScore + ")";
        }

        /// <summary>
        /// Show UI score elements when game's end
        /// <example> Example(s):
        /// <code>
        ///     UIScore.ShowEndGameUIScoreElements();
        /// </code>
        /// </example>
        /// </summary>
        public void ShowEndGameUIScoreElements()
        {
            EndGameScore.SetActive(true);
            TotalScoreText.text = "Score total: " + ScoreManager.Instance.TotalScore;
            DistanceScoreText.text = "Distance\t" + ScoreManager.Instance.DistanceScore;
            KillScoreText.text = "Ennemis tués\t" + ScoreManager.Instance.EnemyKilledScore;
            HitScoreText.text = "Coups reçus\t-" + ScoreManager.Instance.HitScore;
        }

        /// <summary>
        /// Hide End Game score
        /// </summary>
        public void HideEndGameUIScoreElements()
        {
            EndGameScore.SetActive(false);
        }
    }
}
