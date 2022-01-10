using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Manage the continue button in Game Over Menu
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ContinueButton : MonoBehaviour
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
            //TODO : add if(infinite or select track state)
            MenuRoot.ShowTrackSelectionMenu();
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
