using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    public class PauseMenu : MonoBehaviour
    {
        public bool isGamePaused = false;
        public GameObject MenuPauseUI;

        public void Awake()
        {
            GlobalEvent.Resume.AddListener(Resume);
            GlobalEvent.Pause.AddListener(PauseGame);
        }

        public void Resume()
        {
            if(GameManager.Instance.getIsPlaying() == true)
            {
                MenuPauseUI.SetActive(false);
                Time.timeScale = 1f;
                isGamePaused = false;
            }

        }

        public void PauseGame()
        {
            if(GameManager.Instance.getIsPlaying() == true)
            {
                MenuPauseUI.SetActive(true);
                Time.timeScale = 0f;
                isGamePaused = true;
            }

        }

        public void OnDestroy() {
            GlobalEvent.Resume.RemoveListener(Resume);
            GlobalEvent.Pause.RemoveListener(PauseGame);
        }
    }
}