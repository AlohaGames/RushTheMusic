using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class HeroSelectionMenu : MonoBehaviour
    {
        public HeroType Type;
        public MenuRoot MenuRoot;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// Event called when the user click on the button
        /// </summary>
        public void OnClick()
        {
            MenuRoot.Hide();
            GameManager.Instance.LoadHero(Type);
            GameManager.Instance.StartLevel();
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
