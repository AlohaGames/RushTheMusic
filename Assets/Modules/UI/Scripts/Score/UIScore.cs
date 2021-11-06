using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
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

        public void ShowInGameUIScoreElements()
        {
            InGameScore.SetActive(true);
            UpdateUIText();
        }

        public void UpdateUIText()
        {
            InGameScoreText.text = "Score: " + ScoreManager.Instance.TotalScore;
        }

        public void ShowEndGameUIScoreElements()
        {
            EndGameScore.SetActive(true);
            TotalScoreText.text = "Score total: " + ScoreManager.Instance.TotalScore;
            DistanceScoreText.text = "Distance\t" + ScoreManager.Instance.DistanceScore;
            KillScoreText.text = "Ennemis tués\t" + ScoreManager.Instance.EnemyKilledScore;
            HitScoreText.text = "Coups reçus\t" + ScoreManager.Instance.HitScore;
        }
    }
}