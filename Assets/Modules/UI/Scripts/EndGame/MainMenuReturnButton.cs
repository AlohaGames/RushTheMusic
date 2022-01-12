using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Manage the main menu return button in EndGame Menu
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class MainMenuReturnButton : MonoBehaviour
    {
        public MenuRoot MenuRoot;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// Manage actions where button is clicked
        /// </summary>
        void OnClick()
        {
            MenuRoot.ShowMainMenu();
            GameManager.Instance.FinishGame();
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
