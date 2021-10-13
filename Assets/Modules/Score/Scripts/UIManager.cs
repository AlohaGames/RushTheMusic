using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aloha.Score;
using Aloha;

namespace Aloha.Score
{
    public class UIManager : MonoBehaviour
    {
        private ScoreManager instanceScoreManager = ScoreManager.Instance;
        public Text scoreText;
        public GameObject canvasUILevel;

        public void Awake()
        {
            canvasUILevel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + instanceScoreManager.CalculateTotalScore();
            if (TilesManager.Instance.gameIsStarted)
            {
                Canvas_UI_Level();
            }
        }

        public void Canvas_UI_Level()
        {
            GameObject text;
            //Text totalScoreText;

            canvasUILevel.SetActive(true);

            text = new GameObject();
            text.transform.parent = canvasUILevel.transform;
            text.name = "Total_Score_Text";
            //totalScoreText.text = "Score final: " + instanceScoreManager.CalculateTotalScore();
        }
    }
}