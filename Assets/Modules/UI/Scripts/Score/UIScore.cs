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
        }
    }
}
