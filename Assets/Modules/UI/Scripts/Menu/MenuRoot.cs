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
        public GameObject ProfilMenu;
        public GameObject MainMenu;
        public GameObject TrackSelectionMenu;
        public GameObject CharacterMenu;
        public GameObject SettingsMenu;
        public GameObject GameOverMenu;
        public GameObject PauseMenu;
        public GameObject EndGameMenu;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            // The first screen to load
            ShowProfilMenu();
            GlobalEvent.GameOver.AddListener(ShowGameOverMenu);
            GlobalEvent.Resume.AddListener(HideEverything);
            GlobalEvent.Pause.AddListener(ShowPauseMenu);
            GlobalEvent.Victory.AddListener(ShowEndGameMenu);
        }

        /// <summary>
        /// Hide every components registered of the UI
        /// <example> Example(s):
        /// <code>
        /// menuRoot.HideEverything()
        /// </code>
        /// </example>
        /// </summary>
        public void HideEverything()
        {
            ProfilMenu.SetActive(false);
            MainMenu.SetActive(false);
            TrackSelectionMenu.SetActive(false);
            CharacterMenu.SetActive(false);
            SettingsMenu.SetActive(false);
            GameOverMenu.SetActive(false);
            PauseMenu.SetActive(false);
            EndGameMenu.SetActive(false);
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
            GameOverMenu.SetActive(true);
        }

        /// <summary>
        /// Show the pause menu and stop the music
        /// <example> Example(s):
        /// <code>
        ///     ShowPauseMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowPauseMenu()
        {
            this.HideEverything();
            PauseMenu.SetActive(true);
        }

        /// <summary>
        /// Freeze the game, show the pause menu and stop the music
        /// <example> Example(s):
        /// <code>
        ///     ShowPauseMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowEndGameMenu()
        {
            this.HideEverything();
            EndGameMenu.SetActive(true);
            EndGameMenu.transform.Find("TotalScore").GetComponent<Text>().text = "Score total: " + ScoreManager.Instance.TotalScore;
            EndGameMenu.transform.Find("ScoreDetail").Find("DistanceScore").GetComponent<Text>().text = "Distance" + "\t\t" + ScoreManager.Instance.DistanceScore;
            EndGameMenu.transform.Find("ScoreDetail").Find("KillScore").GetComponent<Text>().text = "Ennemis tués\t" + ScoreManager.Instance.EnemyKilledScore;
            EndGameMenu.transform.Find("ScoreDetail").Find("HitScore").GetComponent<Text>().text = "Coups reçus\t-" + ScoreManager.Instance.HitScore;
        }

        /// <summary>
        /// Is called when MonoBehaviour is Destroy
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.GameOver.RemoveListener(ShowGameOverMenu);
            GlobalEvent.Resume.RemoveListener(HideEverything);
            GlobalEvent.Pause.RemoveListener(ShowPauseMenu);
            GlobalEvent.Victory.RemoveListener(ShowEndGameMenu);
        }
    }
}
