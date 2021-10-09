using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    public class UIManager : MonoBehaviour
    {
        public Text scoreText;
        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score total: " + ScoreManager.Instance.CalculateTotalScore().ToString();
        }
    }
}