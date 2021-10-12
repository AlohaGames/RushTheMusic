using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Aloha.Score;
using Aloha;

namespace Aloha
{
    public class UIManager : MonoBehaviour
    {
        private Text scoreText;

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score total: " + ScoreManager.Instance.CalculateTotalScore().ToString();
            if(!TilesManager.Instance.gameIsStarted){
                InitScoreLevelCanvas();
            }
        }

        public void InitScoreLevelCanvas(){
            GameObject myGO;
            GameObject myText;
            Canvas Canvas_UI_Score_Level_Test;
            Text totalScoreText;

            //Canvas
            myGO = new GameObject();
            myGO.name = "Canvas_UI_Score_Level_Test";
            myGO.AddComponent<Canvas>();

            Canvas_UI_Score_Level_Test = myGO.GetComponent<Canvas>();
            Canvas_UI_Score_Level_Test.renderMode = RenderMode.ScreenSpaceOverlay;
            myGO.AddComponent<CanvasScaler>();
            myGO.AddComponent<GraphicRaycaster>();

            //Text score
            myText = new GameObject();
            myText.transform.parent = myGO.transform;
            myText.name = "totalScoreText";
            totalScoreText = myText.AddComponent<Text>();
            totalScoreText.text = "Bite";
        }
    }
}