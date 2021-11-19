using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
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
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void ShowGameOverUI()
        {
            // Put the timeScale to 0, active my UI And stop the game
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            GameManager.Instance.SetIsPlaying(false);
            AudioManager.Instance.StopMusic();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(ShowGameOverUI);
        }
    }
}
