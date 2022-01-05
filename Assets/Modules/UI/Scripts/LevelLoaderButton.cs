using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the level loader button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class LevelLoaderButton : MonoBehaviour
    {
        [SerializeField]
        private bool isTuto = false;

        public string Level;   

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// Called when the user click on the button
        /// <example> Example(s):
        /// <code>
        ///     GetComponent<Button>().onClick.AddListener(OnClick);
        /// </code>
        /// </example>
        /// </summary>
        public void OnClick()
        {
            GameManager.Instance.LoadLevel(Level, isTuto);
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
