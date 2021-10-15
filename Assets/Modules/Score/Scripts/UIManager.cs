using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Aloha.Score
{
    public class UIManager : MonoBehaviour
    {
        private ScoreManager instanceScoreManager;
        private GameManager instanceGameManager;
        public GameObject canvasUIScoreLevel;
        public Text scoreText;
        public Text totalScoreText;
        public Text distanceScore;
        public Text killScore;
        public Text hitScore;

        public void Awake()
        {
            instanceScoreManager = ScoreManager.Instance;
            instanceGameManager = GameManager.Instance;
            canvasUIScoreLevel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + instanceScoreManager.CalculateTotalScore();
            Debug.Log("Played? - " + instanceGameManager.isPlaying);
            if (!instanceGameManager.isPlaying)
            {
                Canvas_UI_Score_Level();
            }
        }

        public void Canvas_UI_Score_Level()
        {
            scoreText.gameObject.SetActive(false);
            canvasUIScoreLevel.SetActive(true);
            distanceScore.text = "Distance" + "\t" + instanceScoreManager.ScoreDistance() + "\n\t\t" + "BITE";
            killScore.text = "Kill" + "\t" + instanceScoreManager.ScoreKill();
            hitScore.text = "Hit" + "\t" + instanceScoreManager.ScoreHit();
            totalScoreText.text = "Score total: " + instanceScoreManager.CalculateTotalScore();
        }
    }
}