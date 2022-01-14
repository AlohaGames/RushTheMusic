using System;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;
using System.Collections.Generic;

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

        private Stack<Action> navigationHistory = new Stack<Action>();

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
            navigationHistory.Push(ShowProfilMenu);

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
            navigationHistory.Push(ShowMainMenu);
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
            navigationHistory.Push(ShowTrackSelectionMenu);
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
            navigationHistory.Push(ShowCharacterMenu);
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
            navigationHistory.Push(ShowOptionMenu);
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
            navigationHistory.Push(ShowGameOverMenu);
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
            navigationHistory.Push(ShowPauseMenu);
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
            navigationHistory.Push(ShowEndGameMenu);

            EndGameMenu.transform.Find("TotalScore").GetComponent<Text>().text = "Score total" + "\t\t" + ScoreManager.Instance.TotalScore;
            EndGameMenu.transform.Find("ScoreDetail").Find("DistanceScore").GetComponent<Text>().text = "Distance" + "\t\t\t\t" + ScoreManager.Instance.DistanceScore;
            EndGameMenu.transform.Find("ScoreDetail").Find("KillScore").GetComponent<Text>().text = "Ennemis tués" + "\t\t" + ScoreManager.Instance.EnemyKilledScore;
            EndGameMenu.transform.Find("ScoreDetail").Find("HitScore").GetComponent<Text>().text = "Coups reçus" + "\t\t\t" + "-" + ScoreManager.Instance.HitScore;
        }

        /// <summary>
        /// Show the last menu in the stack
        /// <example> Example(s):
        /// <code>
        ///     ShowLastMenu()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowLastMenu()
        {
            if (navigationHistory.Count != 0)
            {
                // Remove actual menu from the stack
                navigationHistory.Pop();

                if (navigationHistory.Count != 0)
                {
                    // Get last menu from the stack
                    Action LastMenuAction = navigationHistory.Pop();

                    // Go to the last menu
                    LastMenuAction();
                }
            }
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
