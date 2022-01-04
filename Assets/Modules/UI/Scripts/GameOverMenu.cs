using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// This class manage the GameOverMenu
    /// </summary>
    public class GameOverMenu : MonoBehaviour
    {
        public GameObject GameOverUI;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.GameOver.AddListener(ShowGameOverUI);
        }

        /// <summary>
        /// Stop the game, show the menu and stop the music
        /// <example> Example(s):
        /// <code>
        ///     ShowGameOverUI()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowGameOverUI()
        {
            // Put the timeScale to 0, active the UI And stop the game
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            GameManager.Instance.IsPlaying = false;
            AudioManager.Instance.StopMusic();
        }

        /// <summary>
        /// Is called when MonoBehaviour is Destroy
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(ShowGameOverUI);
        }
    }
}
