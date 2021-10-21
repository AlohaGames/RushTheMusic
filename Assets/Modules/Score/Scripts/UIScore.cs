using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    public class UIScore : MonoBehaviour
    {
        private ScoreManager instanceScoreManager;
        public GameObject canvasUIScoreLevel;
        public Text scoreText;
        public Text totalScoreText;
        public Text distanceScore;
        public Text killScore;
        public Text hitScore;

        public void Awake()
        {
            GlobalEvent.HeroDie.AddListener(Canvas_UI_Score_Level);
            instanceScoreManager = ScoreManager.Instance;
            canvasUIScoreLevel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + instanceScoreManager.CalculateTotalScore();
        }

        public void Canvas_UI_Score_Level()
        {
            scoreText.gameObject.SetActive(false);
            canvasUIScoreLevel.SetActive(true);
            distanceScore.text = "Distance" + "\t" + instanceScoreManager.ScoreDistance();
            killScore.text = "Kill" + "\t" + instanceScoreManager.ScoreKill();
            hitScore.text = "Hit" + "\t" + instanceScoreManager.ScoreHit();
            totalScoreText.text = "Score total: " + instanceScoreManager.CalculateTotalScore();
        }

        public void OnDestroy()
        {
            GlobalEvent.HeroDie.RemoveListener(Canvas_UI_Score_Level);
        }
    }
}