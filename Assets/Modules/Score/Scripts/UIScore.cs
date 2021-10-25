using Aloha.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    public class UIScore : MonoBehaviour
    {
        public GameObject canvasUIScoreLevel;
        public Text scoreText;
        public Text totalScoreText;
        public Text distanceScore;
        public Text killScore;
        public Text hitScore;

        public void Awake()
        {
            GlobalEvent.LevelStop.AddListener(Canvas_UI_Score_Level);
            canvasUIScoreLevel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + ScoreManager.Instance.TotalScore;
        }

        public void Canvas_UI_Score_Level()
        {
            scoreText.gameObject.SetActive(false);
            canvasUIScoreLevel.SetActive(true);
            distanceScore.text = "Distance" + "\t" + ScoreManager.Instance.ScoreDistance();
            killScore.text = "Kill" + "\t" + ScoreManager.Instance.ScoreKill();
            hitScore.text = "Hit" + "\t-" + ScoreManager.Instance.ScoreHit();
            totalScoreText.text = "Score total: " + ScoreManager.Instance.TotalScore;
        }

        public void OnDestroy()
        {
            GlobalEvent.LevelStop.RemoveListener(Canvas_UI_Score_Level);
        }
    }
}