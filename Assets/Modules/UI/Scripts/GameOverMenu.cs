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
            //je met le temps du temps à 0, j'active le menu du game over et je met la variable isPlaying a false
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            GameManager.Instance.setIsPlaying(false);
        }

        public void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(ShowGameOverUI);
        }
    }
}

