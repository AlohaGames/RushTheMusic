using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        public bool IsGamePaused = false;
        public GameObject MenuPauseUI;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.Resume.AddListener(Resume);
            GlobalEvent.Pause.AddListener(PauseGame);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void Resume()
        {
            MenuPauseUI.SetActive(false);
            Time.timeScale = 1f;
            IsGamePaused = false;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void PauseGame()
        {
            MenuPauseUI.SetActive(true);
            Time.timeScale = 0f;
            IsGamePaused = true;
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        public void OnDestroy()
        {
            GlobalEvent.Resume.RemoveListener(Resume);
            GlobalEvent.Pause.RemoveListener(PauseGame);
        }
    }
}
