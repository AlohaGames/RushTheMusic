using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Class for the score UI
    /// </summary>
    public class UIScore : MonoBehaviour
    {
        public GameObject InGameScore;
        public Text InGameScoreText;
        public Text InGameScoreInfiniText;

        /// <summary>
        /// Method to hide score UI
        /// <example> Example(s):
        /// <code>
        ///     UIScore.Hide();
        /// </code>
        /// </example>
        /// </summary>
        public void Hide()
        {
            InGameScore.SetActive(false); ;
        }

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

            // Show total score if inifinite mode is ON
            if (GameManager.Instance.IsInfinite)
            {
                InGameScoreInfiniText.gameObject.SetActive(true);
            }
            else
            {
                InGameScoreInfiniText.gameObject.SetActive(false);
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
            InGameScoreText.text = "Score : " + ScoreManager.Instance.TotalScore;
            InGameScoreInfiniText.text = "(Total : " + ScoreManager.Instance.InfiniteScore + ")";
        }
    }
}
