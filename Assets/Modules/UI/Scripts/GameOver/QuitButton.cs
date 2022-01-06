using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Manage the quit button in the Game Over Menu
    /// </summary>
    [RequireComponent(typeof(Button))]
   public class QuitButton : MonoBehaviour
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
