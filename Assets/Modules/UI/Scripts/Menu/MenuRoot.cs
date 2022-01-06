using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Manage the menu root UI
    /// Can change menu easily with short methods
    /// </summary>
    public class MenuRoot : MonoBehaviour
    {
        public GameObject GameName;
        public GameObject ProfilMenu;
        public GameObject MainMenu;
        public GameObject TrackSelectionMenu;
        public GameObject CharacterMenu;
        public GameObject SettingsMenu;
        public GameObject GameOverMenu;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake() {
            // The first screen to load
            ShowProfilMenu();
            GlobalEvent.GameOver.AddListener(ShowGameOverMenu);
        }

        /// <summary>
        /// Hide menu root UI completely
        /// <example> Example(s):
        /// <code>
        /// menuRoot.Hide()
        /// </code>
        /// </example>
        /// </summary>
        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        /// <summary>
        /// Hide every components registered of the UI
        /// <example> Example(s):
        /// <code>
        /// menuRoot.HideEverything()
        /// </code>
        /// </example>
        /// </summary>
        private void HideEverything()
        {
            this.Show();
            GameName.SetActive(false);
            ProfilMenu.SetActive(false);
            MainMenu.SetActive(false);
            TrackSelectionMenu.SetActive(false);
            CharacterMenu.SetActive(false);
            SettingsMenu.SetActive(false);
            GameOverMenu.SetActive(false);
        }

        /// <summary>
        /// Show menu root UI
        /// <example> Example(s):
        /// <code>
        /// menuRoot.Show()
        /// </code>
        /// </example>
        /// </summary>
        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// Show only profil menu and hide other components
        /// <example> Example(s):
        /// <code>
        /// menuRoot.ShowProfilMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowProfilMenu()
        {
            this.HideEverything();
            GameName.SetActive(true);
            ProfilMenu.SetActive(true);

            // Force profiles loading
            ChooseProfilMenu cpm = ProfilMenu.GetComponent<ChooseProfilMenu>();
            cpm.DisplayProfils();
        }

        /// <summary>
        /// Show only main menu and hide other components
        /// <example> Example(s):
        /// <code>
        /// menuRoot.ShowMainMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowMainMenu()
        {
            this.HideEverything();
            GameName.SetActive(true);
            MainMenu.SetActive(true);
        }

        /// <summary>
        /// Show only track selection menu and hide other components
        /// <example> Example(s):
        /// <code>
        /// menuRoot.ShowTrackSelectionMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowTrackSelectionMenu()
        {
            this.HideEverything();
            GameName.SetActive(true);
            TrackSelectionMenu.SetActive(true);
        }

        /// <summary>
        /// Show only character menu and hide other components
        /// <example> Example(s):
        /// <code>
        /// menuRoot.ShowCharacterMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowCharacterMenu()
        {
            this.HideEverything();
            CharacterMenu.SetActive(true);
        }

        /// <summary>
        /// Show only option menu and hide other components
        /// <example> Example(s):
        /// <code>
        /// menuRoot.ShowOptionMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowOptionMenu()
        {
            this.HideEverything();
            SettingsMenu.SetActive(true);
        }

        /// <summary>
        /// Stop the game, show the menu and stop the music
        /// <example> Example(s):
        /// <code>
        ///     ShowGameOverMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowGameOverMenu()
        {
            this.HideEverything();
            // Put the timeScale to 0, active the UI And stop the game
            Time.timeScale = 0f;
            GameOverMenu.SetActive(true);
            GameManager.Instance.FinishGame();
        }

        /// <summary>
        /// Is called when MonoBehaviour is Destroy
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(ShowGameOverMenu);
        }
    }
}
