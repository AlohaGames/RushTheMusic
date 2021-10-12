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
        public Text scoreText;

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score total: " + ScoreManager.Instance.CalculateTotalScore().ToString();
            if(!TilesManager.Instance.gameIsStarted){
                scoreText.text = SceneManager.GetActiveScene().name.ToString();
            }
        }
    }
}