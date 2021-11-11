using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;


namespace Aloha
{
    public class GameOverMenu : MonoBehaviour
    {

        public GameObject GameOverUI;

        private void Awake()
        {
            GlobalEvent.GameOver.AddListener(ShowGameOverUI);
        }


        public void ShowGameOverUI()
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }
    }
}

