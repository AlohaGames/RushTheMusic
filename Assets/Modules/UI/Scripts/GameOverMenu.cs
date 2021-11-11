using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class GameOverMenu : MonoBehaviour
    {
        public GameObject GameOverUI;

        void Awake()
        {
            GlobalEvent.GameOver.AddListener(ShowGameOverUI);
        }
        
        public void ShowGameOverUI()
        {
            // Put the timeScale to 0, active my UI And stop the game
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            GameManager.Instance.SetIsPlaying(false);
        }

        public void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(ShowGameOverUI);
        }
    }
}

