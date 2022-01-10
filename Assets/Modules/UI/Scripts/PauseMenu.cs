using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the pause menu
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
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
        /// Resume the game
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.Resume.AddListener(Resume);
        /// </code>
        /// </example>
        /// </summary>
        public void Resume()
        {
            MenuPauseUI.SetActive(false);
        }

        /// <summary>
        /// Pause the game
        /// <example> Example(s):
        /// <code>
        ///     GlobalEvent.Pause.RemoveListener(PauseGame);
        /// </code>
        /// </example>
        /// </summary>
        public void PauseGame()
        {
            MenuPauseUI.SetActive(true);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.Resume.RemoveListener(Resume);
            GlobalEvent.Pause.RemoveListener(PauseGame);
        }
    }
}
