using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

namespace Aloha.UI
{
    /// <summary>
    /// Class for the hero invoker button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class HeroSelectionMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private HeroDescription heroDescription;

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
        /// Called when user click on the button
        /// <example> Example(s):
        /// <code>
        ///     GetComponent<Button>().onClick.AddListener(OnClick);
        /// </code>
        /// </example>
        /// </summary>
        public void OnClick()
        {
            MenuRoot.HideEverything();
            GameManager.Instance.LoadHero(Type);
            GameManager.Instance.StartLevel();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            heroDescription.Show(Type);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            heroDescription.Hide();
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
